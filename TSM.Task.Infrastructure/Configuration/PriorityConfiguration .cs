using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TSM.Task.Infrastructure.Configuration;
class PriorityConfiguration : IEntityTypeConfiguration<Domain.Entities.Priority>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Priority> builder)
    {
        builder.ToTable("priority");
        
		builder.HasKey(p => p.Id);
    }
}