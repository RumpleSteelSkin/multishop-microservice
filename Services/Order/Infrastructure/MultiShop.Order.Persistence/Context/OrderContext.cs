using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistence.Context;

public class OrderContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1440;Initial Catalog=MultiShopOrderDb;User=sa;Password=!}W^eG3802,[;Trust Server Certificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ordering>().HasKey(x => x.Id);
        modelBuilder.Entity<Address>().HasKey(x => x.Id);
        modelBuilder.Entity<OrderDetail>().HasKey(x => x.Id);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Ordering> Orderings { get; set; }
}