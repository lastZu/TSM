using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TSM.Task.Infrastructure.Extensions;

namespace TSM.Task.Api;
public class Startup
{
	public IConfiguration Configuration { get; }

	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddInfrastructureReferences(
			"Host=127.0.0.1;Port=5432;Database=TaskDB;Username=tasker;Password=pass"
		);
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		// if (env.IsDevelopment()) ++
		// {
		//     app.UseDeveloperExceptionPage();
		// }
		// else
		// {
		//     app.UseExceptionHandler("/Error");
		//     app.UseHsts();
		// }

		// app.UseHttpsRedirection(); ++
		// app.UseStaticFiles();

		// app.UseRouting(); ++

		// app.UseAuthorization();

		// app.UseEndpoints(endpoints =>
		// {
		//     endpoints.MapRazorPages();
		// });
	}
}
