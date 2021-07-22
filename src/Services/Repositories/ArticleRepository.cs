using AutoMapper;
using Core.Agreement;
using Share.Models;
using Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Agreement;

namespace Services.Repositories
{
    public class ArticleRepository : Repository<Article, ArticleAddDto, ArticleUpdateDto, ArticleFilter, ArticleDto>
    {

        public ArticleRepository(
            ContextBase context,
            IUserContext userContext,
            ILogger<ArticleRepository> logger,
        IMapper mapper) : base(context, logger, userContext, mapper)
        {
        }

        public override Task<PageResult<ArticleDto>> GetListWithPageAsync(ArticleFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            if (filter.AccountId != null && filter.AccountId != Guid.Empty)
            {
                _query = _query.Where(q => q.Account.Id == filter.AccountId);
            }
            if (filter.CatalogId != null && filter.CatalogId != Guid.Empty)
            {
                _query = _query.Where(q => q.Catalog.Id == filter.CatalogId);
            }
            return base.GetListWithPageAsync(filter);
        }

        public override async Task<Article> AddAsync(ArticleAddDto form)
        {
            // 添加文章内容
            var articleExtend = new ArticleExtend
            {
                Content = form.Content
            };
            var article = _mapper.Map<Article>(form);
            var account = _context.Accounts.Find(form.AccountId);
            article.Extend = articleExtend;
            article.Account = account;
            article.AuthorName = account.Username;
            _context.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }


        public override async Task<Article> UpdateAsync(Guid id, ArticleUpdateDto form)
        {
            var article = await _context.Articles.Where(a => a.Id == id)
                .Include(a => a.Extend)
                .SingleOrDefaultAsync();
            var extend = article.Extend;
            article = _mapper.Map<Article>(form);
            extend.Content = form.Content;
            article.Extend = extend;
            article.UpdatedTime = DateTimeOffset.UtcNow;
            await _context.SaveChangesAsync();
            return article;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<Article> GetDetailAsync(Guid id)
        {
            return await _context.Articles.Where(a => a.Id == id)
                .Include(a => a.Extend)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// 是否合法的目录
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        public bool ValidCatalog(Guid catalogId)
        {
            return _context.ArticleCatalogs.Any(ac => ac.Id == catalogId
                && ac.AccountId == _userId.Value);
        }

        /// <summary>
        /// 验证用户
        /// </summary>
        /// <returns></returns>
        public bool ValidAccount()
        {
            var userId = _userId;
            return _db.Any(a => a.AccountId == _usrCtx.UserId);

        }
    }
}
