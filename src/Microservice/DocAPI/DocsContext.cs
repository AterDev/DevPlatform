namespace DocAPI;

public class DocsContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Models.Docs> Docs { get; set; } = default!;
    public DbSet<DocsCatalog> DocsCatalogs { get; set; } = default!;
    public DbSet<WebConfig> WebConfigs { get; set; } = default!;

    public DocsContext(DbContextOptions<DocsContext> options) : base(options)
    {
    }
}
