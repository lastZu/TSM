using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TSM.TaskNS.Infrastructure;
public class TasksContext : DbContext
{
	public DbSet<Task> Tasks { get; set; }
	private readonly string _connectionString;

	public TasksContext(string connectionString)
	{
		_connectionString = connectionString;
		Database.EnsureCreated();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseNpgsql(
			_connectionString
		);
	}
}
