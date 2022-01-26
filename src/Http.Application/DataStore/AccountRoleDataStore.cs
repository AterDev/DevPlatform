using Share.Models.AccountRoleDtos;
namespace Http.Application.DataStore;
public class AccountRoleDataStore : DataStoreBase<ContextBase, AccountRole, AccountRoleUpdateDto, AccountRoleFilter, AccountRoleItemDto>
{
    public AccountRoleDataStore(ContextBase context, IUserContext userContext, ILogger<AccountRoleDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<AccountRoleItemDto>> FindAsync(AccountRoleFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<AccountRoleItemDto>> FindWithPageAsync(AccountRoleFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<AccountRole> AddAsync(AccountRole data) => base.AddAsync(data);
    public override Task<AccountRole?> UpdateAsync(Guid id, AccountRoleUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
