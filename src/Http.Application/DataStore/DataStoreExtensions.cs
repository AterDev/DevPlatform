namespace Http.Application.DataStore;

public static class DataStoreExtensions
{
    public static void AddDataStore(this IServiceCollection services)
    {
        services.AddScoped(typeof(NewsTagsDataStore));
    }
}
