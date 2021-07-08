// 该文件由GT.CLI 工具生成

using Microsoft.Extensions.DependencyInjection;
using Services.Repositories;

namespace App.Api
{
    /// <summary>
    /// 仓储注册服务
    /// </summary>
    public static class RepositoryServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(AccountRepository));
            services.AddScoped(typeof(ArticleCatalogRepository));
            services.AddScoped(typeof(ArticleRepository));
            services.AddScoped(typeof(CatalogRepository));
            services.AddScoped(typeof(CodeSnippetRepository));
            services.AddScoped(typeof(CommentRepository));
            services.AddScoped(typeof(LibraryCatalogRepository));
            services.AddScoped(typeof(LibraryRepository));
            services.AddScoped(typeof(RoleRepository));

        }
    }
}