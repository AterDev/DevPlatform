using Share.Models.LibraryDtos;
using Share.Models.TagLibraryDtos;

namespace Share.Repositories;

public class TagLibraryRepository : Repository<TagLibrary, TagLibraryAddDto, TagLibraryUpdateDto, TagLibraryFilter, TagLibraryDto>
{
    public TagLibraryRepository(ContextBase context, ILogger<TagLibraryRepository> logger, IUserContext userContext, IMapper mapper) : base(context, logger, userContext, mapper)
    {
    }

    public override Task<PageResult<TagLibraryDto>> GetListWithPageAsync(TagLibraryFilter filter)
    {
        _query = _query.OrderByDescending(q => q.CreatedTime);
        if (!string.IsNullOrEmpty(filter.Type))
        {
            _query = _query.Where(q => q.Type.Equals(filter.Type));
        }
        if (!string.IsNullOrEmpty(filter.Name))
        {
            _query = _query.Where(q => q.Type.Contains(filter.Name));
        }
        return base.GetListWithPageAsync(filter);
    }
}
