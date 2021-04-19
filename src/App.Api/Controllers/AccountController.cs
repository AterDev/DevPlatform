using Core.Entity;
using Share.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.Services;
using Core.Services.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using App.Agreement;
using Microsoft.AspNetCore.Authorization;
using Share.Models.Common;
using Microsoft.Extensions.Configuration;

namespace App.Api.Controllers
{
    /// <summary>
    /// Account
    /// </summary>
    public class AccountController : ApiController<AccountRepository, Account, AccountAddDto, AccountUpdateDto, AccountFilter, AccountDto>
    {
        IConfiguration _config;
        public AccountController(
            ILogger<AccountController> logger,
            AccountRepository repository,
            IConfiguration configuration) : base(logger, repository)
        {
            _config = configuration;
        }

        /// <summary>
        /// 添加Account
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public override async Task<ActionResult<Account>> AddAsync([FromBody] AccountAddDto form)
        {
            // if (_repos.Any(e => e.Name == form.Name))
            // {
            //     return Conflict();
            // }
            return await _repos.AddAsync(form);
        }

        /// <summary>
        /// 分页筛选Account
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public override async Task<ActionResult<PageResult<AccountDto>>> FilterAsync(AccountFilter filter)
        {
            return await _repos.GetListWithPageAsync(filter);
        }

        /// <summary>
        /// 更新Account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public override async Task<ActionResult<Account>> UpdateAsync([FromRoute] Guid id, [FromBody] AccountUpdateDto form)
        {
            if (_repos.Any(e => e.Id == id))
            {
                // 名称不可以修改成其他已经存在的名称
                // if (_repos.Any(e => e.Name == form.Name && e.Id != id))
                // {
                //    return Conflict();
                // }
                return await _repos.UpdateAsync(id, form);
            }
            return NotFound();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("signIn")]
        public ActionResult<SignInDto> SignUp([FromBody] SignInForm dto)
        {
            var user = _repos.SignIn(dto);
            if (user == null)
            {
                return NotFound("邮箱不存在或密码错误");
            }
            var jwt = new JwtService();
            var issuerSign = _config.GetSection("Jwt")["Sign"];
            var issuer = _config.GetSection("Jwt")["Issuer"];
            var audience = _config.GetSection("Jwt")["Audience"];

            var roles = string.Join(";", user.Roles.Select(r => r.Name).ToList());
            var token = jwt.BuildToken(user.Id.ToString(), roles, issuerSign, audience, issuer);
            var result = new SignInDto
            {
                Token = token,
                RoleName = roles
            };

            return result;
        }


    }
}