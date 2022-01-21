using Share.Models.NewsTagsDtos;
namespace Http.Application.DataStore;
public class NewsTagsDataStore : DataStoreBase<ContextBase, NewsTags, NewsTagsUpdateDto, NewsTagsFilter, NewsTagsItemDto>
{
    public NewsTagsDataStore(ContextBase context, IUserContext userContext, ILogger<NewsTagsDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<NewsTagsItemDto>> FindAsync(NewsTagsFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<NewsTagsItemDto>> FindWithPageAsync(NewsTagsFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<NewsTags> AddAsync(NewsTags data) => base.AddAsync(data);
    public override Task<NewsTags?> UpdateAsync(Guid id, NewsTagsUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
