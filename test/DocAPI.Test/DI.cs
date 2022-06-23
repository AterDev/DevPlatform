using DocAPI.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocAPI.Test;

public static class DI
{
    private static IServiceProvider Provider()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .AddUserSecrets<UnitTest1>()
            .Build();

        var services = new ServiceCollection();
        var connectionString = config.GetConnectionString("Default");
        services.AddDbContext<DocsContext>(option =>
        {
            option.UseSqlite(connectionString);
        });

        services.AddLogging();
        services.AddTransient(typeof(DocsSyncServices));
        return services.BuildServiceProvider();
    }

    public static T GetService<T>() where T : notnull => Provider().GetRequiredService<T>();
}

