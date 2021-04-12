using Core.Entity;
using GT.Agreement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.Services;
using Core.Services.Models;
using Core.Services.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using NSwag.Annotations;
using Microsoft.AspNetCore.Authorization;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace App.Api.Controllers
{
    /// <summary>
    /// 账号
    /// </summary>
    [OpenApiTag("Account", Description = "Account")]
    public class AccountController : ApiController<AccountRepository, Account, AccountAddDto, AccountUpdateDto, AccountFilter, AccountDto>
    {
        IConfiguration _config;
        public AccountController(
            ILogger<AccountController> logger,
            AccountRepository repository,
             IConfiguration configuration
            ) : base(logger, repository)
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
        /// 邮箱地址验证
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="time">过期时间</param>
        /// <param name="sign">客户端标识</param>
        /// <param name="code">加密code</param>
        /// <returns></returns>
        [HttpGet("verifyEmail")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> VerifyEmailAsync(Guid id, DateTime time, string sign, string code = null)
        {
            // TODO:加密串验证
            if (sign != "geethin") return BadRequest();
            if (time < DateTime.Now) return Ok("链接已失效");
            var account = _repos.SingleOrDefault(r => r.Id == id);
            if (account == null) return NotFound();
            if (account.EmailConfirm == true) return Ok("该邮箱已激活！");

            account.EmailConfirm = true;
            _repos._context.Update(account);
            var res = await _repos._context.SaveChangesAsync();
            if (res == 1) return Ok("邮箱验证成功！");
            return Problem("验证失败");
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<AccountDto> SignUp([FromBody] UserSignUpDto dto)
        {
            var user = _repos.SignUpUser(dto);
            if (user == null)
            {
                return Problem("邮箱不存在或密码错误");
            }
            var jwt = new JwtService();
            var issuerSign = _config.GetSection("Jwt")["Sign"];
            var issuer = _config.GetSection("Jwt")["Issuer"];
            var audience = _config.GetSection("Jwt")["Audience"];
            var token = jwt.BuildToken(user.Id.ToString(), "User", issuerSign, audience, issuer);
            user.Token = token;
            user.RoleName = "User";
            return user;
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("password")]
        public async Task<ActionResult<AccountDto>> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var adminUser = await _repos.ChangePassword(new Guid(id), dto);
            if (adminUser == null) return Problem("原密码错误或该用户已失效");
            return adminUser;
        }
    }
}