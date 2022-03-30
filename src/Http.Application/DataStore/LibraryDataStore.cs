using Share.Models.LibraryDtos;
namespace Http.Application.DataStore;
public class LibraryDataStore : DataStoreBase<ContextBase, Library, LibraryUpdateDto, LibraryFilter, LibraryItemDto>
{
    public LibraryDataStore(ContextBase context, IUserContext userContext, ILogger<LibraryDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<LibraryItemDto>> FindAsync(LibraryFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<LibraryItemDto>> FindWithPageAsync(LibraryFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<Library> AddAsync(Library data) => base.AddAsync(data);
    public override Task<Library?> UpdateAsync(Guid id, LibraryUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
