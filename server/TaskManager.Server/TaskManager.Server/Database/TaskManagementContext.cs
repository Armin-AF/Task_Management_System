using Microsoft.EntityFrameworkCore;

namespace TaskManager.Server.Database;

public class TaskManagementContext: DbContext
{
    public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
        : base(options)
    {
    }

    public DbSet<Models.Task> Tasks { get; set; }
    public DbSet<Models.User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Task>()
            .HasOne(t => t.User)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.UserId);
    }
}