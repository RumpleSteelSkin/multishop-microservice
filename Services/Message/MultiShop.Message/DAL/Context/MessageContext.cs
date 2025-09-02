using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Entities;

namespace MultiShop.Message.DAL.Context;

public class MessageContext(DbContextOptions<MessageContext> options) : DbContext(options)
{
    public DbSet<UserMessage> UserMessages { get; set; }
}