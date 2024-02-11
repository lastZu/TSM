using Microsoft.EntityFrameworkCore;

using TSM.Task.Domain.Entities;

namespace TSM.Task.Infrastructure;
public class TaskContext : DbContext
{
    public DbSet<Domain.Entities.Task> Tasks { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Priority> Priorities { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public TaskContext(DbContextOptions<TaskContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(TaskContext).Assembly
        );
}