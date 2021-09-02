namespace Services.Repositories
{
    public class CatalogRepository : Repository<LibraryCatalog, CatalogAddDto, CatalogUpdateDto, CatalogFilter, CatalogDto>
    {
        public CatalogRepository(ContextBase context, ILogger<CatalogRepository> logger, IUserContext userContext, IMapper mapper) : base(context, logger, userContext, mapper)
        {
        }

        public override Task<PageResult<CatalogDto>> GetListWithPageAsync(CatalogFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            return base.GetListWithPageAsync(filter);
        }
    }
}
