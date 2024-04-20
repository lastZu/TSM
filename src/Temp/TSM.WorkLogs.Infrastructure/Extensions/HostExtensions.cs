using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TSM.WorkLogs.Infrastructure.Extensions;

public static class HostExtensions
{
    public static async System.Threading.Tasks.Task MigrateDatabase(
        this IHost host,
        CancellationToken cancellationToken)
    {
        using (IServiceScope serviceScope = host.Services.CreateScope())
          {
            await serviceScope
                .ServiceProvider
                .GetService<TempContext>()
                .Database.MigrateAsync(cancellationToken);
        }
    }
}
