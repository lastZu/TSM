using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TSM.WorkLogs.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureReferences(
        this IServiceCollection serviceCollection,
        string connectionString)
    {
        serviceCollection
            .AddDbContext<WorkLogContext>(option => option.UseNpgsql(connectionString));
    }
}