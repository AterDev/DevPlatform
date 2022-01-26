using Share.Models.AccountRoleDtos;
namespace Http.API.Controllers;

/// <summary>
/// 用户角色表
/// </summary>
public class AccountRoleController : RestApiBase<AccountRoleDataStore, AccountRole, AccountRoleUpdateDto, AccountRoleFilter, AccountRoleItemDto>
{
    public AccountRoleController(IUserContext user, ILogger<AccountRoleController> logger, AccountRoleDataStore store) : base(user, logger, store)
    {
    }


    /// <summary>
    /// 关联添加
    /// </summary>
    /// <param name="id">所属对象id</param>
    /// <param name="list">数组</param>
    /// <param name="dependStore"></param>
    /// <returns></returns>
    [HttpPost("{id}")]
    public async Task<ActionResult<int>> AddAsync([FromRoute] Guid id, List<AccountRoleUpdateDto> list, [FromServices] AccountDataStore dependStore)
    {
        var depend = await dependStore.FindAsync(id);
        var newList = new List<AccountRole>();
        list.ForEach(item =>
        {
            var newItem = new AccountRole()
            {
                Account = depend
            };
            newList.Add(newItem.Merge(item));
        });
        return await _store.BatchAddAsync(newList);
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public override Task<ActionResult<PageResult<AccountRoleItemDto>>> FilterAsync(AccountRoleFilter filter)
    {
        return base.FilterAsync(filter);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public override Task<ActionResult<AccountRole>> AddAsync(AccountRole form) => base.AddAsync(form);

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public override Task<ActionResult<AccountRole?>> UpdateAsync([FromRoute] Guid id, AccountRoleUpdateDto form)
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
