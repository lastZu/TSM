using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TSM.Task.Infrastructure.Configuration;
class CategoryConfiguration : IEntityTypeConfiguration<Domain.Entities.Category>
{
	public void Configure(EntityTypeBuilder<Domain.Entities.Category> builder)
	{
		builder.ToTable("category");

		builder.HasKey(c => c.Id);
	}
}