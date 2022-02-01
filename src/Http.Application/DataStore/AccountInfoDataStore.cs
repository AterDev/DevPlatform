using Share.Models.AccountInfoDtos;
namespace Http.Application.DataStore;
public class AccountInfoDataStore : DataStoreBase<ContextBase, UserInfo, AccountInfoUpdateDto, AccountInfoFilter, AccountInfoItemDto>
{
    public AccountInfoDataStore(ContextBase context, IUserContext userContext, ILogger<AccountInfoDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<AccountInfoItemDto>> FindAsync(AccountInfoFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<AccountInfoItemDto>> FindWithPageAsync(AccountInfoFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<UserInfo> AddAsync(UserInfo data) => base.AddAsync(data);
    public override Task<UserInfo?> UpdateAsync(Guid id, AccountInfoUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
