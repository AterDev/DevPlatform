namespace IdentityServer;

public partial class DevPlatformContext : DbContext
{
    public DevPlatformContext()
    {
    }

    public DevPlatformContext(DbContextOptions<DevPlatformContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OpenIddictApplication> OpenIddictApplications { get; set; } = null!;
    public virtual DbSet<OpenIddictAuthorization> OpenIddictAuthorizations { get; set; } = null!;
    public virtual DbSet<OpenIddictScope> OpenIddictScopes { get; set; } = null!;
    public virtual DbSet<OpenIddictToken> OpenIddictTokens { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=OpenId;User Id=postgres;Password=root;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OpenIddictApplication>(entity =>
        {
            entity.HasIndex(e => e.ClientId, "IX_OpenIddictApplications_ClientId")
                .IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.ClientId).HasMaxLength(100);

            entity.Property(e => e.ConcurrencyToken).HasMaxLength(50);

            entity.Property(e => e.ConsentType).HasMaxLength(50);

            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<OpenIddictAuthorization>(entity =>
        {
            entity.HasIndex(e => new { e.ApplicationId, e.Status, e.Subject, e.Type }, "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.ConcurrencyToken).HasMaxLength(50);

            entity.Property(e => e.Status).HasMaxLength(50);

            entity.Property(e => e.Subject).HasMaxLength(400);

            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Application)
                .WithMany(p => p.OpenIddictAuthorizations)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK_OpenIddictAuthorizations_OpenIddictApplications_Application~");
        });

        modelBuilder.Entity<OpenIddictScope>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_OpenIddictScopes_Name")
                .IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.ConcurrencyToken).HasMaxLength(50);

            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<OpenIddictToken>(entity =>
        {
            entity.HasIndex(e => new { e.ApplicationId, e.Status, e.Subject, e.Type }, "IX_OpenIddictTokens_ApplicationId_Status_Subject_Type");

            entity.HasIndex(e => e.AuthorizationId, "IX_OpenIddictTokens_AuthorizationId");

            entity.HasIndex(e => e.ReferenceId, "IX_OpenIddictTokens_ReferenceId")
                .IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.ConcurrencyToken).HasMaxLength(50);

            entity.Property(e => e.ReferenceId).HasMaxLength(100);

            entity.Property(e => e.Status).HasMaxLength(50);

            entity.Property(e => e.Subject).HasMaxLength(400);

            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Application)
                .WithMany(p => p.OpenIddictTokens)
                .HasForeignKey(d => d.ApplicationId);

            entity.HasOne(d => d.Authorization)
                .WithMany(p => p.OpenIddictTokens)
                .HasForeignKey(d => d.AuthorizationId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
