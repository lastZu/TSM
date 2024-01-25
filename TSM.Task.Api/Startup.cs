using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
	}

	public void Configure(
		IApplicationBuilder app,
		IWebHostEnvironment env,
		TasksController controller)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}
		app.UseRouting();

		app.UseEndpoints(endpoint =>
		{
			endpoint.MapControllers();
		});

		// app.UseEndpoints(endpoint => endpoint.MapGet("/", () => "Hello"));


		// app.ApplicationServices.GetService<TasksController>();
		// app.UseMiddleware<Cerber>();

		// app.Map("/home", home =>
		// {
		// 	home.Map("/mome", Mome);
		// 	home.Map("/tome", Home);
		// });
		// app.MapWhen(context =>
		// {
		// 		return context.Request.Query.ContainsKey("id")
		// 			&& context.Request.Query["id"] == "ty";
		// }, TyId);
		// app.Run(async (context) =>
		// {
		// 	string str = "";
		// 	foreach (var el in controller.Details())
		// 	{
		// 		str += el.ToString();
		// 	}
		// 	await context.Response.WriteAsync(str);
		// });
	}

	private static void Home(IApplicationBuilder app)
	{
		Default(app, "Home");
	}
	private static void Mome(IApplicationBuilder app)
	{
		Default(app, "Mome");
	}

	private static void TyId(IApplicationBuilder app)
	{
		Default(app, "tytytyt");
	}

	private static void Default(IApplicationBuilder app, string str)
	{
		app.Run(async context =>
			await context.Response.WriteAsync(str)
		);
	}
}

class Cerber
{
	private readonly RequestDelegate _next;
	public Cerber(RequestDelegate next)
	{
		_next = next;
	}

	public async System.Threading.Tasks.Task InvokeAsync(HttpContext context)
	{
		if (context.Request.Query.ContainsKey("meat"))
		{
			await _next.Invoke(context);
		}
		else
			await context.Response.WriteAsync("You are eaten");
	}
}