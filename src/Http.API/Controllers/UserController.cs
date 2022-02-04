using Share.Models.UserDtos;
namespace Http.API.Controllers;

/// <summary>
/// 账号表
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase, IRestApiBase<User, UserUpdateDto, UserFilter, UserItemDto, Guid>
{
    private readonly UserDataStore _store;
    public UserController(IUserContext user, ILogger<UserController> logger, UserDataStore store)
    {
        _store = store;
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<PageResult<UserItemDto>>> FilterAsync([FromQuery] UserFilter filter)
    {
        return await _store.FindWithPageAsync(filter);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<User>> AddAsync(User form)
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
    public async Task<ActionResult<User?>> UpdateAsync([FromRoute] Guid id, UserUpdateDto form)
    {
        var user = await _store.FindAsync(id);
        user.Merge(form);
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
        var user = await _store.FindAsync(id);
        if (user == null) return NotFound();
        return await _store.DeleteAsync(id);

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
    public async Task<ActionResult<User?>> GetDetailAsync([FromRoute] Guid id) => await _store.FindAsync(id);
}
