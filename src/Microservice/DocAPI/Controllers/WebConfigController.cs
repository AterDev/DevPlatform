using DocAPI.Models.WebConfigDtos;
namespace DocAPI.Controllers;

/// <summary>
/// 网站配置
/// </summary>
public class WebConfigController : RestApiBase<WebConfigDataStore, WebConfig, WebConfigUpdateDto, WebConfigFilterDto, WebConfigItemDto>
{
    public WebConfigController(IUserContext user, ILogger<WebConfigController> logger, WebConfigDataStore store) : base(user, logger, store)
    {
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public override async Task<ActionResult<PageResult<WebConfigItemDto>>> FilterAsync(WebConfigFilterDto filter)
    {
        return await base.FilterAsync(filter);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<WebConfig>> AddAsync([FromBody] WebConfig form) => await base.AddAsync(form);

    /// <summary>
    /// 网站配置
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("save")]
    public async Task<ActionResult<WebConfig>> SaveAsync([FromBody] WebConfigAddDto form)
    {
        if (form.Id == null || form.Id == Guid.Empty)
        {
            var data = new WebConfig();
            data = data.Merge(form);
            return await base.AddAsync(data);
        }
        else
        {
            var config = await _store.FindAsync(form.Id.Value);
            if (config == null) return NotFound();
            config.WebSiteName = form.WebSiteName;
            config.Description = form.Description;
            config.GithubUser = form.GithubUser;
            config.GithubPAT = form.GithubPAT;
            await _store._context.SaveChangesAsync();
            return config!;
        }
    }

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<WebConfig?>> UpdateAsync([FromRoute] Guid id, WebConfigUpdateDto form)
        => await base.UpdateAsync(id, form);

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    public override async Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id)
    {
        return await base.DeleteAsync(id);
    }

    /// <summary>
    /// ⚠ 批量删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public override async Task<ActionResult<int>> BatchDeleteAsync(List<Guid> ids)
    {
        // 危险操作，请确保该方法的执行权限
        //return await base.BatchDeleteAsync(ids);
        return await Task.FromResult(0);
    }
}
