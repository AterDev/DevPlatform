using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.Services;

namespace WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            // 请求
            var baseAddress = builder.Configuration.GetValue<string>("BaseAddress");
            if (string.IsNullOrEmpty(baseAddress))
            {
                baseAddress = builder.HostEnvironment.BaseAddress;
            }

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            });
            // 服务
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped(typeof(AuthService));
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            // UI框架
            builder.Services.AddBlazorise(options =>
              {
                  options.ChangeTextOnKeyPress = true;
              })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            // 日志
            builder.Logging.SetMinimumLevel(LogLevel.Debug);

            var host = builder.Build();
            // 初始验证
            var authService = host.Services.GetRequiredService<AuthService>();
            await authService.Initialize();

            await host.RunAsync();
        }
    }
}
