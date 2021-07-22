using AutoMapper;
using Core.Agreement;
using Share.Models;
using Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Agreement;

namespace Services.Repositories
{
    public class CommentRepository : Repository<Comment, CommentAddDto, CommentUpdateDto, CommentFilter, CommentDto>
    {
        public CommentRepository(ContextBase context, ILogger<CommentRepository> logger, IUserContext userContext, IMapper mapper) : base(context, logger, userContext, mapper)
        {
        }

        public override Task<PageResult<CommentDto>> GetListWithPageAsync(CommentFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            return base.GetListWithPageAsync(filter);
        }
    }
}
