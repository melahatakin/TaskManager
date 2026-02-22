using Microsoft.EntityFrameworkCore;
using TaskManager.API.Domain.Entities;

namespace TaskManager.API.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}
