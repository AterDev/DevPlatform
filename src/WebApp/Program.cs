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

            // ����
            var baseAddress = builder.Configuration.GetValue<string>("BaseAddress");
            if (string.IsNullOrEmpty(baseAddress))
            {
                baseAddress = builder.HostEnvironment.BaseAddress;
            }

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            });
            // ����
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped(typeof(AuthService));
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            // UI���
            builder.Services.AddBlazorise(options =>
              {
                  options.ChangeTextOnKeyPress = true;
              })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            // ��־
            builder.Logging.SetMinimumLevel(LogLevel.Debug);

            var host = builder.Build();
            // ��ʼ��֤
            var authService = host.Services.GetRequiredService<AuthService>();
            await authService.Initialize();

            await host.RunAsync();
        }
    }
}
