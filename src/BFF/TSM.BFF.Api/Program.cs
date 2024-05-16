using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TSM.BFF.Api;

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

		await host.RunAsync();
	}
}
