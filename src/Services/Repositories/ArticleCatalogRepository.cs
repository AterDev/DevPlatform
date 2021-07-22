using AutoMapper;
using Core.Agreement;
using Share.Models;
using Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;

namespace Services.Repositories
{
    public class ArticleCatalogRepository : Repository<ArticleCatalog, ArticleCatalogAddDto, ArticleCatalogUpdateDto, ArticleCatalogFilter, ArticleCatalogDto>
    {
        public ArticleCatalogRepository(ContextBase context, ILogger<ArticleCatalogRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        public Task<PageResult<ArticleCatalogDto>> GetListWithPageAsync(Guid accountId, ArticleCatalogFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            _query = _query.Where(c => c.AccountId == accountId);
            return base.GetListWithPageAsync(filter);
        }


        public override Task<ArticleCatalog> AddAsync(ArticleCatalogAddDto form)
        {

            return base.AddAsync(form);
        }


        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public bool ValidAccount(Guid accountId)
        {
            return _context.ArticleCatalogs.Any(a => a.Account.Id == accountId);
        }
    }
}
