using DocAPI.Models.DocsDtos;
namespace DocAPI.DataStore;
public class DocsDataStore : DataStoreBase<DocsContext, Docs, DocsUpdateDto, DocsFilter, DocsItemDto>
{
    public DocsDataStore(DocsContext context, IUserContext userContext, ILogger<DocsDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<DocsItemDto>> FindAsync(DocsFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<DocsItemDto>> FindWithPageAsync(DocsFilter filter)
    {
        _query = _query.OrderBy(d => d.Sort);
        if (filter.DocsCatalogId != null)
        {
            _query = _query.Where(q => q.DocsCatalog.Id == filter.DocsCatalogId);
        }
        if (filter.Language != null)
        {
            _query = _query.Where(q => q.Language == filter.Language);
        }
        return base.FindWithPageAsync(filter);
    }
    public override Task<Docs> AddAsync(Docs data) => base.AddAsync(data);
    public override Task<Docs?> UpdateAsync(Guid id, DocsUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
