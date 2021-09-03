namespace Services.Repositories
{

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
            return await _db.Where(n => n.CreatedTime >= DateTime.Now.AddDays(-7))
                .Where(n => n.Status != Status.Deleted)
                .Where(n => n.Type == NewsType.News)
                .OrderByDescending(n => n.CreatedTime)
                .ToListAsync();
        }

        public override async Task<ThirdNews> DeleteAsync(Guid id)
        {
            var news = await _db.FindAsync(id);
            news.Status = Status.Deleted;
            return news;
        }
        public override Task<ThirdNews> GetDetailAsync(Guid id)
        {
            return base.GetDetailAsync(id);
        }





    }
}
