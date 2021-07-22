using AutoMapper;
using Core.Agreement;
using Share.Models;
using Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;

namespace Services.Repositories
{
    public class CodeSnippetRepository : Repository<CodeSnippet, CodeSnippetAddDto, CodeSnippetUpdateDto, CodeSnippetFilter, CodeSnippetDto>
    {
        public CodeSnippetRepository(ContextBase context, ILogger<CodeSnippetRepository> logger, IMapper mapper) : base(context, logger, mapper)
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
    }
}
