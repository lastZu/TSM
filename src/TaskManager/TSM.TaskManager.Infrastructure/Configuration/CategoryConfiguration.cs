using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSM.TaskManager.Domain.Entities;
using TSM.TaskManager.Domain.Enums;

namespace TSM.TaskManager.Infrastructure.Configuration;
internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.ToTable("category");

		builder.HasKey(c => c.Id);

		builder.HasData(
			GetDefaultCategories()
		);
	}

	private static IReadOnlyList<Category> GetDefaultCategories()
	{
		return
		[
			new Category { Id = (int) Categories.Bug, Name = "Something isn't working" },

			new Category { Id = (int) Categories.Issue, Name = "New feature" },

			new Category { Id = (int) Categories.Question, Name = "Further information is requested" },
		];
	}
}
