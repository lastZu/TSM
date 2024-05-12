using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSM.TaskManager.Domain.Entities;
using TSM.TaskManager.Domain.Enums;

namespace TSM.TaskManager.Infrastructure.Configuration;

internal sealed class PriorityConfiguration : IEntityTypeConfiguration<Priority>
{
	public void Configure(EntityTypeBuilder<Priority> builder)
	{
		builder.ToTable("priority");

		builder.HasKey(p => p.Id);

		builder.HasData(
			GetDefaultPriorities()
		);
	}

	private static IReadOnlyList<Priority> GetDefaultPriorities()
	{
		return
		[
			new Priority { Id = (int) Priorities.High, Name = "Highest" },

			new Priority { Id = (int) Priorities.Medium, Name = "Medium" },

			new Priority { Id = (int) Priorities.Low, Name = "Low" },
		];
	}
}
