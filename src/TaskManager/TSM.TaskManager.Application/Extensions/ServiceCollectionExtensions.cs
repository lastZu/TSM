using Microsoft.Extensions.DependencyInjection;
using TSM.TaskManager.Application.Services.Tags;
using TSM.TaskManager.Application.Services.Tasks;

namespace TSM.TaskManager.Application.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		return services
			.AddTransient<ITaskService, TaskService>()
			.AddTransient<ITagService, TagService>();
	}
}
