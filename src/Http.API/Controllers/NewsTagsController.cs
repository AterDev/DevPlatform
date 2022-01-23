using Http.API.Interface;
using Http.Application.DataStore;
using Http.Application.Interface;
using Share.Models.NewsTagsDtos;

namespace Http.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsTagsController : RestApiBase<NewsTagsDataStore, NewsTags, NewsTagsUpdateDto, NewsTagsFilter, NewsTagsItemDto>
{
    public NewsTagsController(IUserContext user, ILogger<NewsTagsController> logger, NewsTagsDataStore store) : base(user, logger, store)
    {
    }
}
