using AutoMapper;
using Core.Agreement;
using Share.Models;
using Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Services.Repositories
{
    public class LibraryCatalogRepository : Repository<LibraryCatalog, LibraryCatalogAddDto, LibraryCatalogUpdateDto, LibraryCatalogFilter, LibraryCatalogDto>
    {
        public LibraryCatalogRepository(ContextBase context, ILogger<LibraryCatalogRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        public override Task<PageResult<LibraryCatalogDto>> GetListWithPageAsync(LibraryCatalogFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            return base.GetListWithPageAsync(filter);
        }
    }
}
