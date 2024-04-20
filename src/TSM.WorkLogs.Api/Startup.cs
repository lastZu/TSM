using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Hosting;
using TSM.WorkLogs.Infrastructure.Extensions;

namespace TSM.WorkLogs.Api;

public class Startup
{
    private const string AssemblyPrefix = "TSM.WorkLogs";

    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddInfrastructureReferences(
            "Host=127.0.0.1;Port=5432;Database=WorkLogDB;Username=tasker;Password=pass"
        );

        services.AddSwaggerGen();

        services.AddMvcCore()
            .AddApiExplorer()
            .AddControllersAsServices();

        services.AddAutoMapper(AssemblyPrefix);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
        app.UseSwaggerUI();

        app.UseRouting();

        app.UseEndpoints( endpoint => endpoint.MapControllers() );
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
