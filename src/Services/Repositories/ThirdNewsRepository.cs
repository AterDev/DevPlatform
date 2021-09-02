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
        public override Task<ThirdNews> DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
        public override Task<ThirdNews> GetDetailAsync(Guid id)
        {
            return base.GetDetailAsync(id);
        }





    }
}
