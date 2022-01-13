using Share.Models.NewsTagsDtos;
namespace Http.Application.DataStore;
public class NewsTagsDataStore : DataStoreBase<ContextBase, NewsTags, NewsTagsUpdateDto, NewsTagsFilter, NewsTagsItemDto>
{
    public NewsTagsDataStore(ContextBase context, IUserContext userContext, ILogger<NewsTagsDataStore> logger) : base(context, userContext, logger)
    {
    }
}
