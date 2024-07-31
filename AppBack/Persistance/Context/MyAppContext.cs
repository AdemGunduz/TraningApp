using AppBack.Core.Domain;
using AppBack.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AppBack.Persistance.Context
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options): base(options) 
        {

        }
        public DbSet<Product> Products => this.Set<Product>();

        public DbSet<Category> Categories => this.Set<Category>();
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();
        public DbSet<AppRole> AppRoles => this.Set<AppRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
           .Property(p => p.Price)
           .HasColumnType("decimal(18,2)");
        }
    }
}
