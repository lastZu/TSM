using Microsoft.EntityFrameworkCore;
using WorkLogEntity = TSM.WorkLog.Domain.Entities.WorkLog;

namespace TSM.WorkLog.Infrastructure;

public sealed class WorkLogContext : DbContext
{
	public DbSet<WorkLogEntity> WorkLogs { get; set; }

	public WorkLogContext(DbContextOptions options) : base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSnakeCaseNamingConvention();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(
			typeof(WorkLogContext).Assembly
		);
	}
}
