using Share.Models.AccountDtos;
namespace Http.API.Controllers;

/// <summary>
/// 账号表
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AccountController : ControllerBase, IRestApiBase<Account, AccountUpdateDto, AccountFilter, AccountItemDto, Guid>
{
    private readonly AccountDataStore _store;
    public AccountController(IUserContext user, ILogger<AccountController> logger, AccountDataStore store)
    {
        _store = store;
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<PageResult<AccountItemDto>>> FilterAsync([FromQuery] AccountFilter filter)
    {
        return await _store.FindWithPageAsync(filter);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Account>> AddAsync(Account form)
    {
        var res = await  _store.CreateAsync(form);
        if (res.Succeeded) return CreatedAtRoute("", form);
        return Problem(res.ToString());
    }

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<Account?>> UpdateAsync([FromRoute] Guid id, AccountUpdateDto form)
    {
        var account = await _store.FindByIdAsync(id.ToString());
        account.Merge(form);
        var res = await _store.UpdateAsync(account);
        if (res.Succeeded) return account;
        return Problem(res.ToString());
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id)
    {
        var account = await _store.FindByIdAsync(id.ToString());
        var res = await _store.DeleteAsync(account);
        if (res.Succeeded) return true;
        return false;
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
    public async Task<ActionResult<Account?>> GetDetailAsync([FromRoute] Guid id) => await _store.FindByIdAsync(id.ToString());
}
