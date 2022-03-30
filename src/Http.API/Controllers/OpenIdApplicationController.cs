using OpenIddict.Abstractions;
namespace Http.API.Controllers;

[Authorize]
[Route("api/[controller]")]
public class OpenIdApplicationController : ControllerBase
{
    private readonly IOpenIddictApplicationManager _store;
    public OpenIdApplicationController(IUserContext user, ILogger<OpenIdApplicationController> logger, IOpenIddictApplicationManager store)
    {
        _store = store;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OpenIddictApplicationDescriptor?>> GetDetailAsync([FromRoute] Guid id)
    {
        var application = await _store.FindByIdAsync(id.ToString());
        if (application == null) return NotFound();
        return (OpenIddictApplicationDescriptor)application;
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<OpenIddictApplicationDescriptor>> FilterAsync([FromQuery] FilterBase filter)
    {
        if (filter.PageIndex < 1) filter.PageIndex = 1;
        var offset = (filter.PageIndex - 1) * filter.PageSize;
        return (List<OpenIddictApplicationDescriptor>)_store.ListAsync(filter.PageSize, offset);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<OpenIddictApplicationDescriptor>> AddAsync(OpenIddictApplicationDescriptor form)
    {
        var res = await _store.CreateAsync(form);
        return CreatedAtRoute("", res);
    }

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<OpenIddictApplicationDescriptor?>> UpdateAsync([FromRoute] Guid id, OpenIddictApplicationDescriptor form)
    {
        var application = await _store.FindByIdAsync(id.ToString());
        if (application == null) return NotFound();
        await _store.UpdateAsync(application, form);
        return form;

    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var application = await _store.FindByIdAsync(id.ToString());
        if (application == null) return NotFound();
        if (application != null)
            await _store.DeleteAsync(application);
        return Ok();
    }

    /// <summary>
    /// ⚠ 批量删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<ActionResult<int>> BatchDeleteAsync([FromRoute] List<Guid> ids)
    {
        // 危险操作，请确保该方法的执行权限
        //return base.BatchDeleteAsync(ids);
        return await Task.FromResult(0);
    }
}
