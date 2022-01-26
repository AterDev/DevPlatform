using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var config = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json", true, true)
    .AddUserSecrets(typeof(Program).Assembly)
    .AddEnvironmentVariables()
    .Build();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureDefaults(args)
    .ConfigureServices(services =>
    {
        services.AddDbContextPool<ContextBase>(option =>
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            option.UseNpgsql(connectionString,option=>option.MigrationsAssembly("EntityFramework.Migrator"));
        });
    });

host.RunConsoleAsync();
