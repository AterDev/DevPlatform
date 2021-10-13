namespace Services.Repositories;

public class ThirdNewsRepository : Repository<ThirdNews, ThirdNewsAddDto, ThirdNewsUpdateDto, ThirdNewsFilter, ThirdNewsDto>
{

    ILogger _logger;
    public ThirdNewsRepository(ContextBase context, ILogger<ThirdNewsRepository> logger, IUserContext userContext, IMapper mapper)
    : base(context, logger, userContext, mapper)
    {

    }

    public override Task<PageResult<ThirdNewsDto>> GetListWithPageAsync(ThirdNewsFilter filter)
    {
        _query = _query.OrderByDescending(q => q.CreatedTime);
        return base.GetListWithPageAsync(filter);
    }

    public override Task<ThirdNews> AddAsync(ThirdNewsAddDto form)
    {
        return base.AddAsync(form);
    }

    public override Task<ThirdNews> UpdateAsync(Guid id, ThirdNewsUpdateDto form)
    {
        return base.UpdateAsync(id, form);
    }

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
    /// TODO:批量更新
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="newsType"></param>
    /// <returns></returns>
    public async Task<int> SetNewsTypeAsync(List<Guid> ids, NewsType newsType)
    {
        var news = await _db.Where(n => ids.Contains(n.Id)).ToListAsync();
        for (int i = 0; i < news.Count; i++)
        {
            news[i].NewsType = newsType;
        }
        return await _context.SaveChangesAsync();
    }

    public override async Task<ThirdNews> DeleteAsync(Guid id)
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
        for (int i = 0; i < news.Count; i++)
        {
            news[i].Status = Status.Deleted;
        }
        return await _context.SaveChangesAsync();
    }

    public override Task<ThirdNews> GetDetailAsync(Guid id)
    {
        return base.GetDetailAsync(id);
    }

}
