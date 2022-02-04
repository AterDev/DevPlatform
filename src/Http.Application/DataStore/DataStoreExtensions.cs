namespace Http.Application.DataStore;

public static class DataStoreExtensions
{
    public static void AddDataStore(this IServiceCollection services)
    {
        services.AddScoped(typeof(ArticleCatalogDataStore));
        services.AddScoped(typeof(ArticleDataStore));
        services.AddScoped(typeof(ArticleExtendDataStore));
        services.AddScoped(typeof(BaseDBDataStore));
        services.AddScoped(typeof(CodeSnippetDataStore));
        services.AddScoped(typeof(CommentDataStore));
        services.AddScoped(typeof(LibraryCatalogDataStore));
        services.AddScoped(typeof(LibraryDataStore));
        services.AddScoped(typeof(NewsTagsDataStore));
        services.AddScoped(typeof(TagLibraryDataStore));
        services.AddScoped(typeof(ThirdNewsDataStore));
        services.AddScoped(typeof(UserDataStore));
        services.AddScoped(typeof(RoleDataStore));
    }
}
