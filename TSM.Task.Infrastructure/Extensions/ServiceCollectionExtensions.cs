using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TSM.Task.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureReferences(
        this IServiceCollection serviceCollection,
        string connectionString)
    {
        serviceCollection
            .AddDbContext<TaskContext>(option => option.UseNpgsql(connectionString));
    }
}
