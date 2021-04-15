using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ContextBase : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountExtend> AccountExtends { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<CodeSnippet> CodeSnippets { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // 默认配置
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>(e =>
            {
                e.HasIndex(a => a.Email);
                e.HasIndex(a => a.Phone);
                e.HasIndex(a => a.Username);
                e.HasIndex(a => a.IsDeleted);
                e.HasIndex(a => a.PhoneConfirm);
                e.HasIndex(a => a.EmailConfirm);
                e.HasIndex(a => a.CreatedTime);
            });
            builder.Entity<AccountExtend>(e =>
            {
                e.HasIndex(a => a.RealName);
                e.HasIndex(a => a.Country);
                e.HasIndex(a => a.Province);
                e.HasIndex(a => a.City);
            });

            builder.Entity<Role>(e =>
            {
                e.HasIndex(m => m.Name);
                e.HasIndex(m => m.Status);
            });

            builder.Entity<Catalog>(e =>
            {
                e.HasIndex(m => m.Name);
                e.HasIndex(m => m.Type);
                e.HasIndex(m => m.Sort);
                e.HasIndex(m => m.Level);
            });

            builder.Entity<Library>(e =>
            {
                e.HasIndex(m => m.Language);
                e.HasIndex(m => m.IsValid);
                e.HasIndex(m => m.Namespace);
                e.HasIndex(m => m.IsPublic);
                e.HasIndex(m => m.CreatedTime);
            });

            builder.Entity<CodeSnippet>(e =>
            {
                e.HasIndex(m => m.CreatedTime);
                e.HasIndex(m => m.Name);
                e.HasIndex(m => m.Status);
                e.HasIndex(m => m.CodeType);
                e.HasIndex(m => m.Language);
            });
            base.OnModelCreating(builder);
        }
    }
}
