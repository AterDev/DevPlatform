using AutoMapper;
using Core.Agreement;
using Share.Models;
using Core.Entity;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;

namespace Services.Repositories
{
    public class RoleRepository : Repository<Role, RoleAddDto, RoleUpdateDto, RoleFilter, RoleDto>
    {
        public RoleRepository(ContextBase context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Task<PageResult<RoleDto>> GetListWithPageAsync(RoleFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            return base.GetListWithPageAsync(filter);
        }
    }
}
