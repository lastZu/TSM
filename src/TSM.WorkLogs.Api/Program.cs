using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TSM.WorkLogs.Api;
using TSM.WorkLogs.Infrastructure.Extensions;

var builder = Host
    .CreateDefaultBuilder()
    .ConfigureWebHostDefaults(
        builder => builder.UseStartup<Startup>()
    );

var host = builder.Build();

await host.MigrateDatabase(CancellationToken.None);

host.Run();
