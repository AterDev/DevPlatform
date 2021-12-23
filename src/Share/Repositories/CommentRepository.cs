using Share.Models.CommentDtos;

namespace Share.Repositories;

public class CommentRepository : Repository<Comment, CommentAddDto, CommentUpdateDto, CommentFilter, CommentDto>
{
    public CommentRepository(ContextBase context, ILogger<CommentRepository> logger, IUserContext userContext, IMapper mapper) : base(context, logger, userContext, mapper)
    {
    }

    public override Task<PageResult<CommentDto>> GetListWithPageAsync(CommentFilter filter)
    {
        _query = _query.OrderByDescending(q => q.CreatedTime);
        return base.GetListWithPageAsync(filter);
    }
}
