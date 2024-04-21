using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSM.WorkLogs.Domain.Entities;

namespace TSM.WorkLogs.Infrastructure.Configuration;

public class WorkLogConfiguration : IEntityTypeConfiguration<WorkLog>
{
    public void Configure(EntityTypeBuilder<WorkLog> builder)
    {
        builder.ToTable("work_log");

        builder.HasKey(w => w.Id);

        builder
            .Property(w => w.Time)
            .IsRequired();

        builder
            .Property(w => w.Comment)
            .HasMaxLength(1024);

        builder
            .Property(w => w.Date)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        builder
            .Property(w => w.TaskId)
            .IsRequired();
    }
}
