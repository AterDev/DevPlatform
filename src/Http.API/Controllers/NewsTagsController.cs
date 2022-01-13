using Http.Application.DataStore;

namespace Http.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsTagsController : ControllerBase
{
    private readonly NewsTagsDataStore _store;
    public NewsTagsController(NewsTagsDataStore store)
    {
        _store = store;
    }

    public async Task<NewsTags> AddAsync()
    {
        return await _store.AddAsync(new NewsTags
        {
            Name = "test"
        });
    }


}
