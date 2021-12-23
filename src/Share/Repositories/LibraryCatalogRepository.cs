using Share.Models.LibraryCatalogDtos;

namespace Share.Repositories;

public class LibraryCatalogRepository : Repository<LibraryCatalog, LibraryCatalogAddDto, LibraryCatalogUpdateDto, LibraryCatalogFilter, LibraryCatalogDto>
{
    public LibraryCatalogRepository(ContextBase context, ILogger<LibraryCatalogRepository> logger, IUserContext userContext, IMapper mapper) : base(context, logger, userContext, mapper)
    {
    }

    public override Task<PageResult<LibraryCatalogDto>> GetListWithPageAsync(LibraryCatalogFilter filter)
    {
        _query = _query.OrderByDescending(q => q.CreatedTime);
        return base.GetListWithPageAsync(filter);
    }
}
