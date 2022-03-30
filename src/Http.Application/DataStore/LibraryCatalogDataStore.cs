using Share.Models.LibraryCatalogDtos;
namespace Http.Application.DataStore;
public class LibraryCatalogDataStore : DataStoreBase<ContextBase, LibraryCatalog, LibraryCatalogUpdateDto, LibraryCatalogFilter, LibraryCatalogItemDto>
{
    public LibraryCatalogDataStore(ContextBase context, IUserContext userContext, ILogger<LibraryCatalogDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<LibraryCatalogItemDto>> FindAsync(LibraryCatalogFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<LibraryCatalogItemDto>> FindWithPageAsync(LibraryCatalogFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<LibraryCatalog> AddAsync(LibraryCatalog data) => base.AddAsync(data);
    public override Task<LibraryCatalog?> UpdateAsync(Guid id, LibraryCatalogUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
