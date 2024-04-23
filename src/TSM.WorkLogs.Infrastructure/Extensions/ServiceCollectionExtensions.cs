using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TSM.WorkLogs.Infrastructure.Options;

namespace TSM.WorkLogs.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureReferences(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var connectionString = configuration
            .GetSection(PostgreOptions.SectionName)
            .Get<PostgreOptions>().ConnectionString;

        serviceCollection
            .AddDbContext<WorkLogContext>(option => option.UseNpgsql(connectionString));
    }
}
