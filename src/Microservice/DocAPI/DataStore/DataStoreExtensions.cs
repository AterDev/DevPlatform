namespace DocAPI.DataStore;

public static class DataStoreExtensions
{
    public static void AddDataStore(this IServiceCollection services)
    {
        services.AddScoped(typeof(DocsCatalogDataStore));
        services.AddScoped(typeof(DocsDataStore));

    }
}
