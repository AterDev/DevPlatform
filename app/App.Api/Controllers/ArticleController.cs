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
    /// 文章
    /// </summary>
    public class ArticleController : ApiController<ArticleRepository, Article, ArticleAddDto, ArticleUpdateDto, ArticleFilter, ArticleDto>
    {
        protected Guid UserId = Guid.Empty;
        public ArticleController(
            ILogger<ArticleController> logger,
            ArticleRepository repository,
            IHttpContextAccessor accessor
            ) : base(logger, repository)
        {
            var context = accessor.HttpContext;
            var id = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserId = new Guid(id);
        }

        /// <summary>
        /// 添加Article
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public override async Task<ActionResult<Article>> AddAsync([FromBody] ArticleAddDto form)
        {
            if (_repos.Any(e => e.Title == form.Title
                && e.Account.Id == UserId))
            {
                return Conflict();
            }
            var catalog = _repos.ValidCatalog(form.CatalogId, UserId);
            if (!catalog)
            {
                return NotFound("未找到相应的目录");
            }
            form.AccountId = UserId;
            return await _repos.AddAsync(form);
        }

        /// <summary>
        /// 分页筛选Article
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public override async Task<ActionResult<PageResult<ArticleDto>>> FilterAsync(ArticleFilter filter)
        {
            filter.AccountId = UserId;
            return await _repos.GetListWithPageAsync(filter);
        }

        /// <summary>
        /// 更新Article
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public override async Task<ActionResult<Article>> UpdateAsync([FromRoute] Guid id, [FromBody] ArticleUpdateDto form)
        {
            if (_repos.Any(e => e.Id == id))
            {
                // 名称不可以修改成其他已经存在的名称
                if (_repos.Any(e => e.Title == form.Title && e.Id != id))
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
        /// 删除Article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public override async Task<ActionResult<Article>> DeleteAsync([FromRoute] Guid id)
        {
            if (!_repos.ValidAccount(UserId))
            {
                return Forbid();
            }
            return await base.DeleteAsync(id);
        }

        /// <summary>
        /// 获取Article详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public override async Task<ActionResult<Article>> GetDetailAsync([FromRoute] Guid id)
        {
            if (!_repos.ValidAccount(UserId))
            {
                return Forbid();
            }
            return await base.GetDetailAsync(id);
        }
    }
}