using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TSM.WorkLog.Infrastructure.Options;

namespace TSM.WorkLog.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddInfrastructureReferences(
		this IServiceCollection serviceCollection,
		IConfiguration configuration)
	{
		var connectionString = configuration
			.GetSection(PostgreOptions.SectionName)
			.Get<PostgreOptions>().ConnectionString;

		serviceCollection
			.AddDbContext<WorkLogContext>(option => option.UseNpgsql(connectionString));
	}
}
