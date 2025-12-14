using CoreService.Domain.Entities;
using CoreService.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    //public DbSet<Item> Items => Set<Item>();

    public DbSet<ItemEntity> Items => Set<ItemEntity>();
}
