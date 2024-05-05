using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TSM.Task.Infrastructure.Extensions;

public static class HostExtensions
{
	public static async System.Threading.Tasks.Task MigrateDatabase(
		this IHost host,
		CancellationToken cancellationToken)
	{
		using (IServiceScope serviceScope = host.Services.CreateScope())
		  {
			await serviceScope
				.ServiceProvider
				.GetService<TaskContext>()
				.Database.MigrateAsync(cancellationToken);
		}
	}
}
