using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TSM.WorkLog.Application.Services;
using TSM.WorkLog.Infrastructure.Extensions;
using TSM.WorkLogs.Application.Services;

namespace TSM.WorkLog.Api;

internal sealed class Startup
{
	private const string AssemblyPrefix = "TSM.WorkLogs";

	public IConfiguration Configuration { get; }

	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddInfrastructureReferences(Configuration);

		services.AddTransient<IWorkLogService, WorkLogService>();

		services.AddSwaggerGen(option =>
		{
			const string version = "v1";

			var openApiInfo = new OpenApiInfo
			{
				Title = "WorkLog API",
				Description = "Time tracking by task",
				Version = version,
			};
			option.SwaggerDoc(version, openApiInfo);
		});

		services.AddMvcCore()
			.AddApiExplorer()
			.AddControllersAsServices();

		services.AddAutoMapper(AssemblyPrefix);
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
			options.SwaggerEndpoint("/swagger/v1/swagger.json", "WorkLog API V1")
		);

		app.UseRouting();

		app.UseEndpoints(endpoint => endpoint.MapControllers());
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
