using Share.Models.CommentDtos;
namespace Http.Application.DataStore;
public class CommentDataStore : DataStoreBase<ContextBase, Comment, CommentUpdateDto, CommentFilter, CommentItemDto>
{
    public CommentDataStore(ContextBase context, IUserContext userContext, ILogger<CommentDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<CommentItemDto>> FindAsync(CommentFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<CommentItemDto>> FindWithPageAsync(CommentFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<Comment> AddAsync(Comment data) => base.AddAsync(data);
    public override Task<Comment?> UpdateAsync(Guid id, CommentUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
