using Share.Models.AccountExtendDtos;
namespace Http.Application.DataStore;
public class AccountExtendDataStore : DataStoreBase<ContextBase, AccountExtend, AccountExtendUpdateDto, AccountExtendFilter, AccountExtendItemDto>
{
    public AccountExtendDataStore(ContextBase context, IUserContext userContext, ILogger<AccountExtendDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<AccountExtendItemDto>> FindAsync(AccountExtendFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<AccountExtendItemDto>> FindWithPageAsync(AccountExtendFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<AccountExtend> AddAsync(AccountExtend data) => base.AddAsync(data);
    public override Task<AccountExtend?> UpdateAsync(Guid id, AccountExtendUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
