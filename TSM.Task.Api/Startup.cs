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

		services.AddTaskApiDocumentation(
			title: "Tasks API",
			description: "Keep track of your tasks",
			version: "v1"
		);
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		app.UseRouting();

		app.UseSwaggerForTasks("Tasks API V1");

		app.UseEndpoints(endpoint =>
		{
			endpoint.MapControllers();
		});
	}
}