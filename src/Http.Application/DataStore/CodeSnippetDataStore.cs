using Share.Models.CodeSnippetDtos;
namespace Http.Application.DataStore;
public class CodeSnippetDataStore : DataStoreBase<ContextBase, CodeSnippet, CodeSnippetUpdateDto, CodeSnippetFilter, CodeSnippetItemDto>
{
    public CodeSnippetDataStore(ContextBase context, IUserContext userContext, ILogger<CodeSnippetDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<CodeSnippetItemDto>> FindAsync(CodeSnippetFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<CodeSnippetItemDto>> FindWithPageAsync(CodeSnippetFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<CodeSnippet> AddAsync(CodeSnippet data) => base.AddAsync(data);
    public override Task<CodeSnippet?> UpdateAsync(Guid id, CodeSnippetUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
