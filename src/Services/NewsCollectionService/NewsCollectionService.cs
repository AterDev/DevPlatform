using Microsoft.Extensions.Logging;

namespace Services.NewsCollectionService;

/// <summary>
/// 采集服务
/// </summary>
public class NewsCollectionService
{
    readonly ILogger _logger;
    public NewsCollectionService(ILogger<NewsCollectionService> logger)
    {
        _logger = logger;
    }

    public void Start()
    {
        var helper = new RssHelper();
        var news = helper.GetAllBlogs();

        _logger.LogInformation("finish");
    }
}

