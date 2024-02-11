using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSM.Task.Domain.Entities;

namespace TSM.Task.Infrastructure.Configuration;
class TaskConfiguration : IEntityTypeConfiguration<Domain.Entities.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
    {
        builder.ToTable("task");

        builder.HasKey(t => t.Id);

        builder
            .Property(t => t.Title)
            .IsRequired();

        builder
            .Property(t => t.Deadline)
            .HasColumnType("timestamp without time zone")
            .IsRequired(false);

        builder
            .Property(t => t.Comment)
            .HasMaxLength(1024);

        builder
            .HasOne(t => t.Category)
            .WithMany()
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(t => t.Priority)
            .WithMany()
            .HasForeignKey(t => t.PriorityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(t => t.Tag)
            .WithMany()
            .HasForeignKey(t => t.TagId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}