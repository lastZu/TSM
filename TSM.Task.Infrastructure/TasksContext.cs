using Microsoft.EntityFrameworkCore;

using TSM.Task.Domain.Entities;

namespace TSM.Task.Infrastructure;
public class TaskContext : DbContext
{
	public DbSet<Domain.Entities.Task> Tasks { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Priority> Priorities { get; set; }

	public TaskContext(DbContextOptions<TaskContext> options)
		: base(options)
	{
		// TODO - Remove before setup Migration
		// Database.EnsureDeleted();
		// Database.EnsureCreated();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseSnakeCaseNamingConvention();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder) =>
		modelBuilder.ApplyConfigurationsFromAssembly(
			typeof(TaskContext).Assembly
		);
}