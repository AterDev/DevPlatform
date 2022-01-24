using Share.Models.NewsTagsDtos;

namespace Http.API.Controllers;

/// <summary>
/// 新闻标签
/// </summary>
public class NewsTagsController : RestApiBase<NewsTagsDataStore, NewsTags, NewsTagsUpdateDto, NewsTagsFilter, NewsTagsItemDto>
{
    public NewsTagsController(IUserContext user, ILogger<NewsTagsController> logger, NewsTagsDataStore store) : base(user, logger, store)
    {
    }

    public override Task<ActionResult<PageResult<NewsTagsItemDto>>> FilterAsync(NewsTagsFilter filter)
    {
        return base.FilterAsync(filter);
    }

    public override Task<ActionResult<NewsTags>> AddAsync(NewsTags form)
    {
        return base.AddAsync(form);
    }

    public override Task<ActionResult<NewsTags?>> UpdateAsync([FromRoute] Guid id, NewsTagsUpdateDto form)
        => base.UpdateAsync(id, form);

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public override Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id)
    {
        return base.DeleteAsync(id);
    }

    /// <summary>
    /// ⚠ 批量删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public override async Task<ActionResult<int>> BatchDeleteAsync(List<Guid> ids)
    {
        // 危险操作，请确保该方法的执行权限
        //return base.BatchDeleteAsync(ids);
        return await Task.FromResult(0);
    }
}
