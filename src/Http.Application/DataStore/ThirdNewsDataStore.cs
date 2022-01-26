using Share.Models.ThirdNewsDtos;
namespace Http.Application.DataStore;
public class ThirdNewsDataStore : DataStoreBase<ContextBase, ThirdNews, ThirdNewsUpdateDto, ThirdNewsFilter, ThirdNewsItemDto>
{
    public ThirdNewsDataStore(ContextBase context, IUserContext userContext, ILogger<ThirdNewsDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<ThirdNewsItemDto>> FindAsync(ThirdNewsFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<ThirdNewsItemDto>> FindWithPageAsync(ThirdNewsFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<ThirdNews> AddAsync(ThirdNews data) => base.AddAsync(data);
    public override Task<ThirdNews?> UpdateAsync(Guid id, ThirdNewsUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
