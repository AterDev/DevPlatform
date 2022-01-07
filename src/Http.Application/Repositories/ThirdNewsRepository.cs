using Share.Models.TagLibraryDtos;
using Share.Models.ThirdNewsDtos;

namespace Http.Application.Repositories;

public class ThirdNewsRepository : Repository<ThirdNews, ThirdNewsAddDto, ThirdNewsUpdateDto, ThirdNewsFilter, ThirdNewsDto>
{
    private ILogger _logger;
    public ThirdNewsRepository(ContextBase context, ILogger<ThirdNewsRepository> logger, IUserContext userContext, IMapper mapper)
    : base(context, logger, userContext, mapper)
    {

    }

    public override Task<PageResult<ThirdNewsDto>> GetListWithPageAsync(ThirdNewsFilter filter)
    {
        _query = _query.OrderByDescending(q => q.CreatedTime);
        return base.GetListWithPageAsync(filter);
    }

    public override Task<ThirdNews> AddAsync(ThirdNewsAddDto form) => base.AddAsync(form);

    public override Task<ThirdNews> UpdateAsync(Guid id, ThirdNewsUpdateDto form) => base.UpdateAsync(id, form);

    /// <summary>
    /// 添加标签
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tags"></param>
    /// <returns></returns>
    public async Task<ThirdNews> AddTags(Guid id, List<NewsTagsAddDto> tags)
    {
        var thirdNews = await _db.FindAsync(id);
        var newsTags = new List<NewsTags>();
        tags.ForEach(t =>
        {
            var newsTag = _mapper.Map<NewsTags>(t);
            newsTag.ThirdNews = thirdNews!;
            newsTags.Add(newsTag);
        });
        _context.AddRange(newsTags);
        await _context.SaveChangesAsync();
        return thirdNews!;
    }

    public async Task<int> DeleteTag(Guid id)
    {
        var tag = _context.NewsTags?.FindAsync(id);
        if (tag != null)
        {
            _context.Remove(tag);
            return await _context.SaveChangesAsync();
        }
        return 0;
    }

    /// <summary>
    /// 获取一周内资讯
    /// </summary>
    /// <returns></returns>
    public async Task<List<ThirdNews>> GetWeekNewsAsync()
    {
        var offset = (int)DateTime.Now.Date.DayOfWeek;
        if (offset == 0) offset = 7;
        return await _db.Where(n => n.CreatedTime >= DateTime.Now.AddDays(-offset))
            .Where(n => n.Status != Status.Deleted)
            .Where(n => n.Type == NewsSource.News)
            .OrderByDescending(n => n.CreatedTime)
            .ToListAsync();
    }

    /// <summary>
    /// 批量更新
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="newsType"></param>
    /// <returns></returns>
    public async Task<int> SetNewsTypeAsync(List<Guid> ids, TechType newsType)
    {
        var news = await _db.Where(n => ids.Contains(n.Id)).ToListAsync();
        for (var i = 0; i < news.Count; i++)
        {
            news[i].TechType = newsType;
        }
        return await _context.SaveChangesAsync();
    }

    public async override Task<ThirdNews> DeleteAsync(Guid id)
    {
        var news = await _db.FindAsync(id);
        news.Status = Status.Deleted;
        await _context.SaveChangesAsync();
        return news;
    }

    /// <summary>
    /// set news as deleted
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public async Task<int> RemoveAsync(List<Guid> ids)
    {
        var news = await _db.Where(n => ids.Contains(n.Id)).ToListAsync();
        for (var i = 0; i < news.Count; i++)
        {
            news[i].Status = Status.Deleted;
        }
        return await _context.SaveChangesAsync();
    }

    public override Task<ThirdNews> GetDetailAsync(Guid id) => base.GetDetailAsync(id);

}
