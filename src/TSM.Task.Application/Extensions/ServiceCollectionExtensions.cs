using Microsoft.Extensions.DependencyInjection;
using TSM.Task.Application.Services.Tags;
using TSM.Task.Application.Services.Tasks;

namespace TSM.Task.Application.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		return services
			.AddTransient<ITaskService, TaskService>()
			.AddTransient<ITagService, TagService>();
	}
}
