using Share.Models.TagLibraryDtos;
namespace Http.Application.DataStore;
public class TagLibraryDataStore : DataStoreBase<ContextBase, TagLibrary, TagLibraryUpdateDto, TagLibraryFilter, TagLibraryItemDto>
{
    public TagLibraryDataStore(ContextBase context, IUserContext userContext, ILogger<TagLibraryDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<TagLibraryItemDto>> FindAsync(TagLibraryFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<TagLibraryItemDto>> FindWithPageAsync(TagLibraryFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<TagLibrary> AddAsync(TagLibrary data) => base.AddAsync(data);
    public override Task<TagLibrary?> UpdateAsync(Guid id, TagLibraryUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
