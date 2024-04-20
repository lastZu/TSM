using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSM.Task.Domain.Entities;
using TSM.Task.Domain.Enums;

namespace TSM.Task.Infrastructure.Configuration;

class PriorityConfiguration : IEntityTypeConfiguration<Priority>
{
    public void Configure(EntityTypeBuilder<Priority> builder)
    {
        builder.ToTable("priority");

        builder.HasKey(p => p.Id);

        builder.HasData(
            GetDefaultPriorities()
        );
    }

    private static IEnumerable<Priority> GetDefaultPriorities()
    {
        return new List<Priority>
        {
            new Priority { Id = (int) Priorities.High, Name = "Highest" },

            new Priority { Id = (int) Priorities.Medium, Name = "Medium" },

            new Priority { Id = (int) Priorities.Low, Name = "Low" },
        };
    }
}
