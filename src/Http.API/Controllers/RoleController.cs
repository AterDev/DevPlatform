using Share.Models.RoleDtos;
namespace Http.API.Controllers;

/// <summary>
/// 角色表
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RoleController : ControllerBase, IRestApiBase<Role, RoleUpdateDto, RoleFilter, RoleItemDto, Guid>
{
    private readonly RoleDataStore _store;
    public RoleController(IUserContext user, ILogger<RoleController> logger, RoleDataStore store)
    {
        _store = store;
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<PageResult<RoleItemDto>>> FilterAsync(RoleFilter filter)
    {
        return await _store.FindWithPageAsync(filter);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Role>> AddAsync(Role form)
    {
        var res = await _store.AddAsync(form);
        return CreatedAtRoute("", res);
    }

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<Role?>> UpdateAsync([FromRoute] Guid id, RoleUpdateDto form)
    {
        var Role = await _store.FindAsync(id);
        Role.Merge(form);
        var res = await _store.UpdateAsync(id, form);
        return res;

    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id)
    {
        var role = await _store.FindAsync(id);
        if (role == null) return NotFound();
        var res = await _store.DeleteAsync(id);
        return res;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<Role?>> GetDetailAsync([FromRoute] Guid id) => await _store.FindAsync(id);
}
