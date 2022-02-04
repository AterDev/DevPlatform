using Share.Models.ThirdNewsDtos;
namespace Http.API.Controllers;

public class ThirdNewsController : RestApiBase<ThirdNewsDataStore, ThirdNews, ThirdNewsUpdateDto, ThirdNewsFilter, ThirdNewsItemDto>
{
    public ThirdNewsController(IUserContext user, ILogger<ThirdNewsController> logger, ThirdNewsDataStore store) : base(user, logger, store)
    {
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public override Task<ActionResult<PageResult<ThirdNewsItemDto>>> FilterAsync(ThirdNewsFilter filter)
    {
        return base.FilterAsync(filter);
    }

    [HttpGet("week")]
    public Task<List<ThirdNews>> GetWeekNewsAsync() => _store.GetWeekNewsAsync();
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public override Task<ActionResult<ThirdNews>> AddAsync(ThirdNews form) => base.AddAsync(form);

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public override Task<ActionResult<ThirdNews?>> UpdateAsync([FromRoute] Guid id, ThirdNewsUpdateDto form)
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
    public async override Task<ActionResult<int>> BatchDeleteAsync(List<Guid> ids)
    {
        // 危险操作，请确保该方法的执行权限
        //return base.BatchDeleteAsync(ids);
        return await Task.FromResult(0);
    }
}
