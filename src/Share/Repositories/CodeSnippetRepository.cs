using Share.Models.CodeSnippetDtos;

namespace Share.Repositories;

public class CodeSnippetRepository : Repository<CodeSnippet, CodeSnippetAddDto, CodeSnippetUpdateDto, CodeSnippetFilter, CodeSnippetDto>
{
    public CodeSnippetRepository(ContextBase context, ILogger<CodeSnippetRepository> logger, IUserContext userContext, IMapper mapper) : base(context, logger, userContext, mapper)
    {
    }

    public override Task<PageResult<CodeSnippetDto>> GetListWithPageAsync(CodeSnippetFilter filter)
    {
        _query = _query.OrderByDescending(q => q.CreatedTime);
        return base.GetListWithPageAsync(filter);
    }


    public bool Any(Guid userId, string name, CodeType codeType, Language language)
    {
        return _db.Any(o => o.Name == name
        && o.CodeType == codeType
        && o.Language == language
        && o.Library.User.Id == userId);
    }

    public bool Exist(CodeSnippetUnique dto)
    {
        return _db.Any(d => d.Name == dto.Name
            && d.Language == dto.Language
            && d.CodeType == dto.CodeType);
    }
}
