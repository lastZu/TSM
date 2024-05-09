using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSM.WorkLogs.Domain.Entities;

namespace TSM.WorkLogs.Infrastructure.Configuration;

internal sealed class WorkLogConfiguration : IEntityTypeConfiguration<WorkLog>
{
	public void Configure(EntityTypeBuilder<WorkLog> builder)
	{
		builder.ToTable("work_log");

		builder.HasKey(w => w.Id);

		builder
			.Property(w => w.Comment)
			.HasMaxLength(1024);

		builder
			.Property(w => w.Date)
			.HasColumnType("timestamp without time zone");
	}
}
