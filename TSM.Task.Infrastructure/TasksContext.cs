using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TSM.TaskNS.Infrastructure;
public class TasksContext : DbContext
{
	public DbSet<Task> Tasks { get; set; }
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
        var taskBuilder = modelBuilder.Entity<Task>();
		// taskBuilder
		// 	.HasOne<Category>()
		// 	.WithMany().OnDelete(DeleteBehavior.SetNull)
			// .HasForeignKey(t => t.CategoryId)
		;
		taskBuilder
			.Property(t => t.Dedline)
			.HasColumnType("timestamp without time zone")
			.HasDefaultValue(DateTime.Now)
		;
		// taskBuilder.Property<Category>.

		// var categoryBuilder = modelBuilder.Entity<Category>();
		// categoryBuilder.Property
    }
}
