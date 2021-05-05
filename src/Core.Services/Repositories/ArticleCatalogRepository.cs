using AutoMapper;
using Core.Agreement;
using Share.Models;
using Core.Entity;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using System;

namespace Core.Services.Repositories
{
    public class ArticleCatalogRepository : Repository<ArticleCatalog, ArticleCatalogAddDto, ArticleCatalogUpdateDto, ArticleCatalogFilter, ArticleCatalogDto>
    {
        public ArticleCatalogRepository(ContextBase context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Task<PageResult<ArticleCatalogDto>> GetListWithPageAsync(ArticleCatalogFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            return base.GetListWithPageAsync(filter);
        }


        public override Task<ArticleCatalog> AddAsync(ArticleCatalogAddDto form)
        {
            if (form.ParentId == null || form.ParentId == Guid.Empty)
            {
                form.Level = 0;
            }
            else
            {
                var parent = _context.ArticleCatalogs.Find(form.ParentId);
                form.Level = (short)(parent.Level + 1);

            }
            return base.AddAsync(form);
        }
    }
}
