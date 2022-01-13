using System;
using EntityFramework;
using Http.Application.Agreement;
using Http.Application.DataStore;
using Http.Application.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Http.API.Test.Helper;

public static class DI
{
    private static IServiceProvider Provider()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .AddUserSecrets<DataStoreTest>()
            .Build();

        var services = new ServiceCollection();
        var connectionString = config.GetConnectionString("DefaultConnection");
        services.AddDbContext<ContextBase>(option =>
        {
            option.UseNpgsql(connectionString);
        });

        services.AddLogging();
        services.AddScoped<IUserContext, UserContext>();
        services.AddDataStore();
        return services.BuildServiceProvider();
    }

    public static T GetService<T>() => Provider().GetRequiredService<T>();
}

