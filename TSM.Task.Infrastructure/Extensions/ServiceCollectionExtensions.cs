using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TSM.Task.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddInfrastructureReferences(
		this IServiceCollection serviceCollection,
		string conectionString)
	{
		serviceCollection.AddDbContext<TaskContext>(
			option => option.UseNpgsql(conectionString)
		);
	}
}