using Http.Application.Interface;
using Http.Application.Repositories;
using Share.Models.ArticleCatalogDtos;

namespace Http.API.Controllers;

/// <summary>
/// 文章目录
/// </summary>
public class ArticleCatalogController : ApiController<ArticleCatalogRepository, ArticleCatalog, ArticleCatalogAddDto, ArticleCatalogUpdateDto, ArticleCatalogFilter, ArticleCatalogDto>
{

    protected Guid UserId = Guid.Empty;
    public ArticleCatalogController(
        ILogger<ArticleCatalogController> logger,
             IUserContext userContext,
        ArticleCatalogRepository repository) : base(logger, repository, userContext)
    {
    }

    /// <summary>
    /// 添加ArticleCatalog
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async override Task<ActionResult<ArticleCatalog>> AddAsync([FromBody] ArticleCatalogAddDto form)
    {
        if (_repos._db.Any(e => e.Name == form.Name
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
            var parent = _repos._db.SingleOrDefault(p => p.Id == form.ParentId);
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
    public async override Task<ActionResult<PageResult<ArticleCatalogDto>>> FilterAsync(ArticleCatalogFilter filter) => await _repos.GetListWithPageAsync(UserId, filter);

    /// <summary>
    /// 更新ArticleCatalog
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async override Task<ActionResult<ArticleCatalog>> UpdateAsync([FromRoute] Guid id, [FromBody] ArticleCatalogUpdateDto form)
    {
        if (_repos._db.Any(e => e.Id == id))
        {
            // 名称不可以修改成其他已经存在的名称
            if (_repos._db.Any(e => e.Name == form.Name && e.Id != id))
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
    public async override Task<ActionResult<ArticleCatalog>> DeleteAsync([FromRoute] Guid id)
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
    public async override Task<ActionResult<ArticleCatalog>> GetDetailAsync([FromRoute] Guid id)
    {
        if (!_repos.ValidAccount(UserId))
        {
            return Forbid();
        }
        return await base.GetDetailAsync(id);
    }
}
