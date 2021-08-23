using EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Services.Repositories
{
    public class RoleRepository : Repository<Role, RoleAddDto, RoleUpdateDto, RoleFilter, RoleDto>
    {
        public RoleRepository(ContextBase context, ILogger<RoleRepository> logger, IUserContext userContext, IMapper mapper) : base(context, logger, userContext, mapper)
        {
        }

        public override Task<PageResult<RoleDto>> GetListWithPageAsync(RoleFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            return base.GetListWithPageAsync(filter);
        }

    }
}
