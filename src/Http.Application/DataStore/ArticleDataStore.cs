using Share.Models.ArticleDtos;
namespace Http.Application.DataStore;
public class ArticleDataStore : DataStoreBase<ContextBase, Article, ArticleUpdateDto, ArticleFilter, ArticleItemDto>
{
    public ArticleDataStore(ContextBase context, IUserContext userContext, ILogger<ArticleDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<ArticleItemDto>> FindAsync(ArticleFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<ArticleItemDto>> FindWithPageAsync(ArticleFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<Article> AddAsync(Article data) => base.AddAsync(data);
    public override Task<Article?> UpdateAsync(Guid id, ArticleUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
