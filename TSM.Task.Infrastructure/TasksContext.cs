using System;
using Microsoft.EntityFrameworkCore;

using TSM.Task.Domain.Entities;

namespace TSM.Task.Infrastructure;
public class Context : DbContext
{
	public DbSet<Domain.Entities.Task> Tasks { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Priority> Priorities { get; set; }
	private readonly string _connectionString;

	public Context(string connectionString)
	{
		_connectionString = connectionString;
		Database.EnsureDeleted();
		Database.EnsureCreated();
	}

	public Context(DbContextOptions options)
		: base(options)
	{

	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseNpgsql(
			_connectionString
		);
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var taskBuilder = modelBuilder.Entity<Domain.Entities.Task>();
		taskBuilder
			.Property(i => i.Dedline)
			.HasColumnType("timestamp without time zone")
			.HasDefaultValue(DateTime.Now)
		;
    }
}
