using Share.Models.RoleDtos;
namespace Http.Application.DataStore;
public class RoleDataStore : DataStoreBase<ContextBase, Role, RoleUpdateDto, RoleFilter, RoleItemDto>
{
    public RoleDataStore(ContextBase context, IUserContext userContext, ILogger<RoleDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<RoleItemDto>> FindAsync(RoleFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<RoleItemDto>> FindWithPageAsync(RoleFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<Role> AddAsync(Role data) => base.AddAsync(data);
    public override Task<Role?> UpdateAsync(Guid id, RoleUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
