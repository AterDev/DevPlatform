namespace DocAPI.DataStore;

public static class DataStoreExtensions
{
    public static void AddDataStore(this IServiceCollection services)
    {
        services.AddTransient<IUserContext, UserContext>();
        services.AddScoped(typeof(DocsCatalogDataStore));
        services.AddScoped(typeof(DocsDataStore));
        services.AddScoped(typeof(UserDataStore));
        services.AddScoped(typeof(WebConfigDataStore));

    }
}
