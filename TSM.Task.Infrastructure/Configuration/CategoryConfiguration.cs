using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TSM.Task.Infrastructure.Configuration;
class CategoryConfiguration : IEntityTypeConfiguration<Domain.Entities.Category>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Category> builder)
    {
        builder.ToTable("Category");
		builder.HasKey(c => c.Id);
    }
}