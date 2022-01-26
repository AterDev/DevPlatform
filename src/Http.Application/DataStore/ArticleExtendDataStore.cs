using Share.Models.ArticleExtendDtos;
namespace Http.Application.DataStore;
public class ArticleExtendDataStore : DataStoreBase<ContextBase, ArticleExtend, ArticleExtendUpdateDto, ArticleExtendFilter, ArticleExtendItemDto>
{
    public ArticleExtendDataStore(ContextBase context, IUserContext userContext, ILogger<ArticleExtendDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<ArticleExtendItemDto>> FindAsync(ArticleExtendFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<ArticleExtendItemDto>> FindWithPageAsync(ArticleExtendFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<ArticleExtend> AddAsync(ArticleExtend data) => base.AddAsync(data);
    public override Task<ArticleExtend?> UpdateAsync(Guid id, ArticleExtendUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
