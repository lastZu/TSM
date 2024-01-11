using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using TSM.TaskNS.Domain;

namespace TSM.TaskNS.Infrastructure;
public class TasksContext : DbContext
{
	public DbSet<Issue> Issues { get; set; }
	public DbSet<Category> Categories { get; set; }
	private readonly string _connectionString;

	public TasksContext(string connectionString)
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
        var taskBuilder = modelBuilder.Entity<Issue>();
		taskBuilder
			.Property(i => i.Dedline)
			.HasColumnType("timestamp without time zone")
			.HasDefaultValue(DateTime.Now)
		;
    }
}
