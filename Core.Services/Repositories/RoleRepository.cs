using AutoMapper;
using GT.Agreement;
using GT.Agreement.Models;
using Core.Entity;
using Core.Services.Models;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;

namespace Core.Services.Repositories
{
    public class RoleRepository : Repository<Role, RoleAddDto, RoleUpdateDto, RoleFilter, RoleDto>
    {
        public RoleRepository(CoreContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Task<PageResult<RoleDto>> GetListWithPageAsync(RoleFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            return base.GetListWithPageAsync(filter);
        }
    }
}
