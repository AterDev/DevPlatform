// 该文件由GT.CLI 工具生成

using Microsoft.Extensions.DependencyInjection;
using Core.Services.Repositories;

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

        }
    }
}
