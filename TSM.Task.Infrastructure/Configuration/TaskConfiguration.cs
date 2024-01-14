using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TSM.Task.Infrastructure.Configuration;
class TaskConfiguration : IEntityTypeConfiguration<Domain.Entities.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
    {
        builder.ToTable("Task");
		builder.HasKey(t => t.Id);

		builder.Property(t => t.Title)
			.IsRequired();

		builder
			.Property(t => t.Dedline)
			.HasColumnType<DateTime?>("timestamp without time zone")
			.HasDefaultValue(DateTime.Now)
			.IsRequired();

		builder.Property(t => t.Comment)
			.HasMaxLength(1024);

		builder.Property(t => t.Category)
			.IsRequired();

		builder.Property(t => t.Priority)
			.IsRequired();

		builder.HasOne(t => t.Category)
			.WithMany()
			.HasForeignKey(t => t.CategoryId)
			.IsRequired();

		builder.HasOne(t => t.Priority)
			.WithMany()
			.HasForeignKey(t => t.PriorityId)
			.IsRequired();
    }
}