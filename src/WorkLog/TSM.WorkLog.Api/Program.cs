using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TSM.WorkLog.Api;
using TSM.WorkLog.Infrastructure.Extensions;

internal sealed class Program
{
	private static async Task Main(string[] args)
	{
		var builder = Host
	.CreateDefaultBuilder()
	.ConfigureWebHostDefaults(
		builder => builder.UseStartup<Startup>()
	);

		var host = builder.Build();

		await host.MigrateDatabase(CancellationToken.None);

		await host.RunAsync();
	}
}
