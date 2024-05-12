using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSM.TaskManager.Domain.Entities;

namespace TSM.TaskManager.Infrastructure.Configuration;

internal sealed class TagConfiguration : IEntityTypeConfiguration<Tag>
{
	public void Configure(EntityTypeBuilder<Tag> builder)
	{
		builder.ToTable("tag");

		builder.HasKey(t => t.Id);

		builder.HasAlternateKey(t => t.Name);

		builder
			.Property(t => t.Name)
			.IsRequired();

		builder
			.Property(t => t.Description)
			.HasMaxLength(1024);
	}
}
