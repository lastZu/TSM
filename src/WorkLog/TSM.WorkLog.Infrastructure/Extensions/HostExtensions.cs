using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TSM.WorkLog.Infrastructure.Extensions;

public static class HostExtensions
{
	public static async System.Threading.Tasks.Task MigrateDatabase(
		this IHost host,
		CancellationToken cancellationToken)
	{
		using var serviceScope = host.Services.CreateScope();
		await serviceScope
			.ServiceProvider
			.GetService<WorkLogContext>()
			.Database.MigrateAsync(cancellationToken);
	}
}
