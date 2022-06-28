using DocAPI.Models.WebConfigDtos;

namespace DocAPI.Controllers;

/// <summary>
/// 网站配置
/// </summary>
public class WebConfigController : RestApiBase<WebConfigDataStore, WebConfig, WebConfigUpdateDto, WebConfigFilterDto, WebConfigItemDto>
{
    private readonly DocsSyncServices _syncService;

    public WebConfigController(
        IUserContext user,
        ILogger<WebConfigController> logger,
        WebConfigDataStore store,
        DocsSyncServices syncService) : base(user, logger, store)
    {
        _syncService = syncService;
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public async override Task<ActionResult<PageResult<WebConfigItemDto>>> FilterAsync(WebConfigFilterDto filter)
    {
        return await base.FilterAsync(filter);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public async override Task<ActionResult<WebConfig>> AddAsync([FromBody] WebConfig form) => await base.AddAsync(form);

    /// <summary>
    /// 保存网站配置
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
            config.RepositoryId = form.RepositoryId;
            await _store._context.SaveChangesAsync();
            return config!;
        }
    }

    /// <summary>
    /// 获取仓库
    /// </summary>
    /// <param name="pat"></param>
    /// <returns></returns>
    [HttpGet("repositories")]
    public async Task<ActionResult<List<RepositoryItemDto>>> GetRepositories(string pat)
    {
        await _syncService.SetPATAsync(pat);
        var list = await _syncService.GetPublicRepositories();
        return list.Select(s => new RepositoryItemDto
        {
            FullName = s.FullName,
            RepositoryId = s.Id
        }).ToList();
    }

    /// <summary>
    /// 同步文档
    /// </summary>
    public async Task<ActionResult> SyncAsync()
    {
        var config = await _store.Db.FirstOrDefaultAsync();
        if (config == null)
        {
            return Problem("请先填写github配置");
        }
        if (string.IsNullOrEmpty(config.GithubPAT) || config.RepositoryId == null)
        {
            return Problem("请先填写github pat并选择对应的文档仓库");
        }
        try
        {
            await _syncService.AutoSyncAsync();
            return Ok("同步完成");
        }
        catch (Exception ex)
        {
            return Problem(ex.Message + ex.StackTrace);
        }
    }

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public async override Task<ActionResult<WebConfig?>> UpdateAsync([FromRoute] Guid id, WebConfigUpdateDto form)
        => await base.UpdateAsync(id, form);

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    public async override Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id)
    {
        return await Task.FromResult(true);
    }

    /// <summary>
    /// ⚠ 批量删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public async override Task<ActionResult<int>> BatchDeleteAsync(List<Guid> ids)
    {
        // 危险操作，请确保该方法的执行权限
        //return await base.BatchDeleteAsync(ids);
        return await Task.FromResult(0);
    }
}
