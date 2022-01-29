using Share.Models.BaseDBDtos;
namespace Http.Application.DataStore;
public class BaseDBDataStore : DataStoreBase<ContextBase, Core.Models.EntityBase, BaseDBUpdateDto, BaseDBFilter, BaseDBItemDto>
{
    public BaseDBDataStore(ContextBase context, IUserContext userContext, ILogger<BaseDBDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<BaseDBItemDto>> FindAsync(BaseDBFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<BaseDBItemDto>> FindWithPageAsync(BaseDBFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<Core.Models.EntityBase> AddAsync(Core.Models.EntityBase data) => base.AddAsync(data);
    public override Task<Core.Models.EntityBase?> UpdateAsync(Guid id, BaseDBUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
