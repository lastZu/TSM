using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkLogEntity = TSM.WorkLog.Domain.Entities.WorkLog;

namespace TSM.WorkLog.Infrastructure.Configuration;

internal sealed class WorkLogConfiguration : IEntityTypeConfiguration<WorkLogEntity>
{
	public void Configure(EntityTypeBuilder<WorkLogEntity> builder)
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
