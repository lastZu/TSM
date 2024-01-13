using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using TSM.Task.Domain;

namespace TSM.Task.Infrastructure;
public class TasksContext : DbContext
{
	public DbSet<Domain.Task> Tasks { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Priority> Priorities { get; set; }
	private readonly string _connectionString;

	public TasksContext(string connectionString)
	// : base(options)
	{
		_connectionString = connectionString;
		Database.EnsureDeleted();
		Database.EnsureCreated();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseNpgsql(
			_connectionString
		);
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var taskBuilder = modelBuilder.Entity<Domain.Task>();
		taskBuilder
			.Property(i => i.Dedline)
			.HasColumnType("timestamp without time zone")
			.HasDefaultValue(DateTime.Now)
		;
    }
}
