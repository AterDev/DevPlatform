using AutoMapper;
using Core.Agreement;
using Share.Models;
using Core.Entity;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;

namespace Core.Services.Repositories
{
    public class ArticleRepository : Repository<Article, ArticleAddDto, ArticleUpdateDto, ArticleFilter, ArticleDto>
    {
        public ArticleRepository(ContextBase context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Task<PageResult<ArticleDto>> GetListWithPageAsync(ArticleFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            return base.GetListWithPageAsync(filter);
        }

        public override async Task<Article> AddAsync(ArticleAddDto form)
        {
            // ÃÌº”Œƒ’¬ƒ⁄»›
            var articleExtend = new ArticleExtend
            {
                Content = form.Content
            };
            var article = _mapper.Map<Article>(form);
            article.Extend = articleExtend;

            _context.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }
    }
}
