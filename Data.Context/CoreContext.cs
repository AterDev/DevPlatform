using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Data.Context
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class CoreContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountExtend> AccountExtends { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Lib> Libs { get; set; }


        public CoreContext([NotNull] DbContextOptions<CoreContext> options) : base(options)
        {
        }

        protected CoreContext()
        {
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

            builder.Entity<Lib>(e =>
            {
                e.HasIndex(m => m.Language);
                e.HasIndex(m => m.IsValid);
                e.HasIndex(m => m.Namespace);
                e.HasIndex(m => m.CreatedTime);
            });

            builder.Entity<Entity>(e =>
            {
                e.HasIndex(m => m.CreatedTime);
                e.HasIndex(m => m.Name);
                e.HasIndex(m => m.Status);
            });

            base.OnModelCreating(builder);
        }
    }
}
