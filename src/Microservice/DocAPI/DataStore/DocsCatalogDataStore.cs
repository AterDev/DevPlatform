using DocAPI.Models.DocsCatalogDtos;
namespace DocAPI.DataStore;
public class DocsCatalogDataStore : DataStoreBase<DocsContext, DocsCatalog, DocsCatalogUpdateDto, DocsCatalogFilter, DocsCatalogItemDto>
{
    public DocsCatalogDataStore(DocsContext context, IUserContext userContext, ILogger<DocsCatalogDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<DocsCatalogItemDto>> FindAsync(DocsCatalogFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<DocsCatalogItemDto>> FindWithPageAsync(DocsCatalogFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<DocsCatalog> AddAsync(DocsCatalog data) => base.AddAsync(data);
    public override Task<DocsCatalog?> UpdateAsync(Guid id, DocsCatalogUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
