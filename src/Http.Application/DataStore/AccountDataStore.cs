using Share.Models.AccountDtos;
namespace Http.Application.DataStore;
public class AccountDataStore : DataStoreBase<ContextBase, Account, AccountUpdateDto, AccountFilter, AccountItemDto>
{
    public AccountDataStore(ContextBase context, IUserContext userContext, ILogger<AccountDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<AccountItemDto>> FindAsync(AccountFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<AccountItemDto>> FindWithPageAsync(AccountFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<Account> AddAsync(Account data) => base.AddAsync(data);
    public override Task<Account?> UpdateAsync(Guid id, AccountUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
