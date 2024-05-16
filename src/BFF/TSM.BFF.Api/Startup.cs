using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace TSM.BFF.Api;

internal sealed class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddMvcCore()
			.AddApiExplorer()
			.AddControllersAsServices();

		services.AddSwaggerGen(option =>
		{
			const string version = "v1";

			var openApiInfo = new OpenApiInfo
			{
				Title = "BFF API",
				Description = "Task Api",
				Version = version,
			};
			option.SwaggerDoc(version, openApiInfo);
		});
	}

	public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}
		else
		{
			app.UseExceptionHandler("/Error");
		}

		app.UseSwagger();
		app.UseSwaggerUI(options =>
			options.SwaggerEndpoint("/swagger/v1/swagger.json", "BFF API V1")
		);

		app.UseRouting();

		app.UseEndpoints(endpoint => endpoint.MapControllers());
	}
}
