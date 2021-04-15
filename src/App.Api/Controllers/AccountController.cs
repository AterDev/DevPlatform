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

namespace App.Api.Controllers
{
    /// <summary>
    /// Account
    /// </summary>
    public class AccountController : ApiController<AccountRepository, Account, AccountAddDto, AccountUpdateDto, AccountFilter, AccountDto>
    {
        public AccountController(
            ILogger<AccountController> logger,
            AccountRepository repository) : base(logger, repository)
        {
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
    }
}