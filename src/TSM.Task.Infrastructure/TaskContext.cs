using Microsoft.EntityFrameworkCore;

namespace TSM.Task.Infrastructure;

public sealed class TaskContext : DbContext
{
	public TaskContext(DbContextOptions<TaskContext> options)
		: base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSnakeCaseNamingConvention();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(
			typeof(TaskContext).Assembly
		);
	}
}
