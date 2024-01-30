using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using TSM.Task.Api.Controllers;
using TSM.Task.Application.Services.Tasks;
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

		services.AddTransient<ITaskService, TasksService>();
		services.AddTransient<TasksController>();
		services.AddControllers();

		services.AddSwaggerGen(options =>
			options.SwaggerDoc(
				"v1",
				new OpenApiInfo { Title = "Tasks API", Description = "Keep track of your tasks", Version = "v1" }
		));
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		app.UseRouting();

		app.UseSwagger();
		app.UseSwaggerUI(options =>
			options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tasks API V1")
		);

		app.UseEndpoints(endpoint =>
		{
			endpoint.MapControllers();
		});
	}
}