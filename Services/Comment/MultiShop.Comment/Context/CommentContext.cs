using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context;

public class CommentContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1442;Initial Catalog=MultiShopCommentDb;User=SA;Password=!}W^eG3802,[;Trust Server Certificate=True;");
    }

    public DbSet<UserComment> UserComments { get; set; }
}