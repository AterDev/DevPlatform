using AutoMapper;
using Core.Agreement;
using Share.Models;
using Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Services.Repositories
{
    public class RoleRepository : Repository<Role, RoleAddDto, RoleUpdateDto, RoleFilter, RoleDto>
    {
        public RoleRepository(ContextBase context, ILogger<RoleRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        public override Task<PageResult<RoleDto>> GetListWithPageAsync(RoleFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            return base.GetListWithPageAsync(filter);
        }

    }
}
