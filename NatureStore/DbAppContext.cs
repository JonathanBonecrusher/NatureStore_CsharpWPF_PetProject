using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureStore
{
    internal class DbAppContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Turnover> Turnover { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Supply> Supply { get; set; }

        public DbSet<Turnover_Product> Turnover_Product { get; set; }

        public DbSet<Supply_Product> Supply_Product { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Username=postgres; Password=1234; Database=Store");
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turnover_Product>().HasOne(p => p.TurnoverEntity).WithMany(p => p.Turnover_Product_Entity);

            modelBuilder.Entity<Turnover_Product>().HasOne(p => p.ProductEntity).WithMany(p => p.Product_Turnover_Entity);

            modelBuilder.Entity<Supply_Product>().HasOne(p => p.SupplyEntity).WithMany(p => p.Supply_Product_Entity);

            modelBuilder.Entity<Supply_Product>().HasOne(p => p.ProductEntity).WithMany(p => p.Product_Supply_Entity);

            modelBuilder.Entity<Supply>().HasOne(p => p.ProviderEntity).WithMany(p => p.SupplyEntity);
        }
    }
}
