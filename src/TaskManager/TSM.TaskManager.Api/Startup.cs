using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Hosting;
using TSM.TaskManager.Api.Extensions;
using TSM.TaskManager.Application.Extensions;
using TSM.TaskManager.Infrastructure.Extensions;

namespace TSM.TaskManager.Api;

internal sealed class Startup
{
	private const string AssemblyPrefix = "TSM.Task";

	public IConfiguration Configuration { get; }

	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddMvcCore()
			.AddApiExplorer()
			.AddControllersAsServices();

		services.AddAutoMapper(AssemblyPrefix);

		services.AddTaskApiDocumentation(
			title: "Tasks API",
			description: "Keep track of your tasks",
			version: "v1"
		);

		services.AddInfrastructureReferences(Configuration.GetConnectionString("TaskContext"));
		services.AddApplicationServices();
	}

	public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		app.UseRouting();

		app.UseSwaggerForTasks("Tasks API V1");

		app.UseEndpoints(endpoint => { endpoint.MapControllers(); });
	}
}

public static class AutoMapperExtensions
{
	public static IServiceCollection AddAutoMapper(this IServiceCollection services, string prefixAssemblyName)
	{
		var assemblies = DependencyContext.Default.RuntimeLibraries
			.SelectMany(lib => lib
				.GetDefaultAssemblyNames(DependencyContext.Default)
				.Where(assemblyName => assemblyName.FullName.StartsWith(prefixAssemblyName))
				.Select(Assembly.Load))
			.ToArray();

		var mapper = new Mapper(new MapperConfiguration(ctx =>
		{
			ctx.AllowNullCollections = true;
			ctx.AddMaps(assemblies);
		}));

		services.AddSingleton<IMapper>(mapper);

		return services;
	}
}
