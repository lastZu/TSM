using Microsoft.EntityFrameworkCore;
using TSM.WorkLogs.Domain.Entities;

namespace TSM.WorkLogs.Infrastructure;

public sealed class WorkLogContext : DbContext
{
    public DbSet<WorkLog> WorkLogs { get; set; }

    public WorkLogContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(WorkLogContext).Assembly
        );
}
