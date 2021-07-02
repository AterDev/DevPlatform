using AutoMapper;
using Core.Agreement;
using Share.Models;
using Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore;

namespace Services.Repositories
{
    public class LibraryRepository : Repository<Library, LibraryAddDto, LibraryUpdateDto, LibraryFilter, LibraryDto>
    {
        public LibraryRepository(ContextBase context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Task<PageResult<LibraryDto>> GetListWithPageAsync(LibraryFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            return base.GetListWithPageAsync(filter);
        }
    }
}
