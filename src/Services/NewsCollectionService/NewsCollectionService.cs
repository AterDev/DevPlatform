namespace Services.NewsCollectionService;

/// <summary>
/// 采集服务
/// </summary>
public class NewsCollectionService
{
    readonly ILogger _logger;

    readonly ContextBase _context;
    public NewsCollectionService(ILogger<NewsCollectionService> logger, ContextBase context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task Start()
    {
        _logger.LogInformation("===Start=== Collect news");
        var list = await GetThirdNewsAsync();
        _logger.LogInformation("===Result=== collect news: " + list.Count);
        _logger.LogInformation("===Start=== Add news");
        await AddThirdNewsAsync(list);
        _logger.LogInformation("===Result=== finish!");
    }

    public async Task<List<ThirdNews>> GetThirdNewsAsync()
    {
        var news = await RssHelper.GetAllBlogsAsync();
        var result = new List<ThirdNews>();
        news.ForEach(news =>
        {
            var thirdNews = new ThirdNews
            {
                Category = news.Categories,
                Description = news.Description,
                Provider = news.Author,
                Title = news.Title,
                Url = news.Link,
                ThumbnailUrl = news.ThumbUrl,
                DatePublished = news.CreateTime,
                Type = NewsType.News
            };
            result.Add(thirdNews);
        });
        _logger.LogInformation("get all news!");
        return result;
    }

    public async Task AddThirdNewsAsync(List<ThirdNews> list)
    {
        var result = new List<ThirdNews>(list);
        var news = await _context.ThirdNews.OrderByDescending(n => n.DatePublished)
            .Where(n => n.Type == NewsType.News)
            .Take(50).ToListAsync();

        _logger.LogInformation("today total news: " + list.Count);

        foreach (var item in list)
        {
            if (news.Any(n => n.Title.GetSimilar(item.Title) >= 0.6 || n.Title.Equals(item.Title)))
            {
                result.Remove(item);
            }
        }
        _logger.LogInformation("added news: " + result.Count);

        if (result.Count > 0)
        {
            await _context.AddRangeAsync(result);
            await _context.SaveChangesAsync();
        }
    }
}

