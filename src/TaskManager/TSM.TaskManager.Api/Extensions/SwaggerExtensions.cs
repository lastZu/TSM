using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TSM.TaskManager.Api.Extensions;

internal static class SwaggerExtensions
{
	public static void AddTaskApiDocumentation(
		this IServiceCollection service,
		string title,
		string description,
		string version)
	{
		service.AddSwaggerGen(options =>
		{
			var openApiInfo = new OpenApiInfo
			{
				Title = title,
				Description = description,
				Version = version,
			};
			options.SwaggerDoc(version, openApiInfo);
		});
	}

	public static void UseSwaggerForTasks(this IApplicationBuilder app, string name)
	{
		app.UseSwagger();
		app.UseSwaggerUI(options =>
			options.SwaggerEndpoint("/swagger/v1/swagger.json", name)
		);
	}
}
