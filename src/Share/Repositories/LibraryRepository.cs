using Share.Models.LibraryDtos;

namespace Share.Repositories;

public class LibraryRepository : Repository<Library, LibraryAddDto, LibraryUpdateDto, LibraryFilter, LibraryDto>
{
    public LibraryRepository(ContextBase context, ILogger<LibraryRepository> logger, IUserContext userContext, IMapper mapper) : base(context, logger, userContext, mapper)
    {
    }

    public override Task<PageResult<LibraryDto>> GetListWithPageAsync(LibraryFilter filter)
    {
        _query = _query.OrderByDescending(q => q.CreatedTime);
        return base.GetListWithPageAsync(filter);
    }
}