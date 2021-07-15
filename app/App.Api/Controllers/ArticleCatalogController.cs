using Entity;
using Share.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using App.Agreement;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace App.Api.Controllers
{
    /// <summary>
    /// 文章目录
    /// </summary>
    public class ArticleCatalogController : ApiController<ArticleCatalogRepository, ArticleCatalog, ArticleCatalogAddDto, ArticleCatalogUpdateDto, ArticleCatalogFilter, ArticleCatalogDto>
    {

        protected Guid UserId = Guid.Empty;
        public ArticleCatalogController(
            ILogger<ArticleCatalogController> logger,
                 IHttpContextAccessor accessor,
            ArticleCatalogRepository repository) : base(logger, repository, accessor)
        {
            var context = accessor.HttpContext;
            var id = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserId = new Guid(id);
        }

        /// <summary>
        /// 添加ArticleCatalog
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public override async Task<ActionResult<ArticleCatalog>> AddAsync([FromBody] ArticleCatalogAddDto form)
        {
            if (_repos.Any(e => e.Name == form.Name
                && e.Account.Id == UserId))
            {
                return Conflict();
            }
            form.AccountId = UserId;
            if (form.ParentId == null || form.ParentId == Guid.Empty)
            {
                form.Level = 0;
            }
            else
            {
                var parent = _repos.SingleOrDefault(p => p.Id == form.ParentId);
                if (parent == null)
                {
                    return NotFound("错误的父类id");
                }
                form.Level = (short)(parent.Level + 1);
            }
            return await _repos.AddAsync(form);
        }

        /// <summary>
        /// 分页筛选ArticleCatalog
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public override async Task<ActionResult<PageResult<ArticleCatalogDto>>> FilterAsync(ArticleCatalogFilter filter)
        {
            return await _repos.GetListWithPageAsync(UserId, filter);
        }

        /// <summary>
        /// 更新ArticleCatalog
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public override async Task<ActionResult<ArticleCatalog>> UpdateAsync([FromRoute] Guid id, [FromBody] ArticleCatalogUpdateDto form)
        {
            if (_repos.Any(e => e.Id == id))
            {
                // 名称不可以修改成其他已经存在的名称
                if (_repos.Any(e => e.Name == form.Name && e.Id != id))
                {
                    return Conflict();
                }
                if (!_repos.ValidAccount(UserId))
                {
                    return Forbid();
                }
                return await _repos.UpdateAsync(id, form);
            }
            return NotFound();
        }


        /// <summary>
        /// 删除ArticleCatalog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public override async Task<ActionResult<ArticleCatalog>> DeleteAsync([FromRoute] Guid id)
        {
            if (!_repos.ValidAccount(UserId))
            {
                return Forbid();
            }
            return await base.DeleteAsync(id);
        }

        /// <summary>
        /// 获取ArticleCatalog详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public override async Task<ActionResult<ArticleCatalog>> GetDetailAsync([FromRoute] Guid id)
        {
            if (!_repos.ValidAccount(UserId))
            {
                return Forbid();
            }
            return await base.GetDetailAsync(id);
        }
    }
}