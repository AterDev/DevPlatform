using DocAPI.Models.WebConfigDtos;
namespace DocAPI.DataStore;
public class WebConfigDataStore : DataStoreBase<DocsContext, WebConfig, WebConfigUpdateDto, WebConfigFilterDto, WebConfigItemDto>
{
    public WebConfigDataStore(DocsContext context, IUserContext userContext, ILogger<WebConfigDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<WebConfigItemDto>> FindAsync(WebConfigFilterDto filter)
    {
        return await base.FindAsync(filter);
    }

    public override async Task<PageResult<WebConfigItemDto>> FindWithPageAsync(WebConfigFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<WebConfig> AddAsync(WebConfig data) => await base.AddAsync(data);
    public override async Task<WebConfig?> UpdateAsync(Guid id, WebConfigUpdateDto dto) => await base.UpdateAsync(id, dto);
    public override async Task<bool> DeleteAsync(Guid id) => await base.DeleteAsync(id);
}
