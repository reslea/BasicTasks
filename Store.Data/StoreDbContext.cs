using System;
using Microsoft.EntityFrameworkCore;

namespace Store.Data
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        public StoreDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(_ => _.Title).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Product>().Property(_ => _.Image).IsRequired().HasMaxLength(1000);

            modelBuilder.Entity<BasketItem>()
                .HasOne(_ => _.Product)
                .WithMany()
                .HasForeignKey(_ => _.ProductId);

            modelBuilder.Entity<BasketItem>()
                .HasOne(_ => _.Basket)
                .WithMany()
                .HasForeignKey(_ => _.BasketId);

            modelBuilder.Entity<Basket>()
                .HasMany(_ => _.BasketItems)
                .WithOne(_ => _.Basket)
                .HasForeignKey(_ => _.BasketId);
        }
    }
}
