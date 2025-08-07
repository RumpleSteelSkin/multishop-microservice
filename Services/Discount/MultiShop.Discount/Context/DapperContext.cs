using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;

namespace MultiShop.Discount.Context;

public class DapperContext(IConfiguration configuration) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Coupon> Coupons { get; set; }

    public IDbConnection CreateConnection() => new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
}