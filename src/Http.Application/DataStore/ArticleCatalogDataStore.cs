using Share.Models.ArticleCatalogDtos;
namespace Http.Application.DataStore;
public class ArticleCatalogDataStore : DataStoreBase<ContextBase, ArticleCatalog, ArticleCatalogUpdateDto, ArticleCatalogFilter, ArticleCatalogItemDto>
{
    public ArticleCatalogDataStore(ContextBase context, IUserContext userContext, ILogger<ArticleCatalogDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<ArticleCatalogItemDto>> FindAsync(ArticleCatalogFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<ArticleCatalogItemDto>> FindWithPageAsync(ArticleCatalogFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<ArticleCatalog> AddAsync(ArticleCatalog data) => base.AddAsync(data);
    public override Task<ArticleCatalog?> UpdateAsync(Guid id, ArticleCatalogUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
