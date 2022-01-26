using Share.Models.ThirdNewsDtos;
namespace Http.Application.DataStore;
public class ThirdNewsDataStore : DataStoreBase<ContextBase, ThirdNews, ThirdNewsUpdateDto, ThirdNewsFilter, ThirdNewsItemDto>
{
    public ThirdNewsDataStore(ContextBase context, IUserContext userContext, ILogger<ThirdNewsDataStore> logger) : base(context, userContext, logger)
    {
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

    public override Task<List<ThirdNewsItemDto>> FindAsync(ThirdNewsFilter filter) => base.FindAsync(filter);
    public override Task<PageResult<ThirdNewsItemDto>> FindWithPageAsync(ThirdNewsFilter filter) => base.FindWithPageAsync(filter);
    public override Task<ThirdNews> AddAsync(ThirdNews data) => base.AddAsync(data);
    public override Task<ThirdNews?> UpdateAsync(Guid id, ThirdNewsUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
