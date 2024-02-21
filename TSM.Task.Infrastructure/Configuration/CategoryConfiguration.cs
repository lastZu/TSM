using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSM.Task.Domain.Entities;
using TSM.Task.Domain.Enums;

namespace TSM.Task.Infrastructure.Configuration;
class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("category");

        builder.HasKey(c => c.Id);

        builder.HasData(
            GetDefaultCategories()
        );
    }

    private static IEnumerable<Category> GetDefaultCategories()
    {
        return new List<Category>
        {
            new Category { Id = (int) Categories.Bug, Name = "Something isn't working" },

            new Category { Id = (int) Categories.Issue, Name = "New feature" },

            new Category { Id = (int) Categories.Question, Name = "Further information is requested" },
        };
    }
}