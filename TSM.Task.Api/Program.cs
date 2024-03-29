using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TSM.Task.Api;
using TSM.Task.Infrastructure.Extensions;

var builder = Host
    .CreateDefaultBuilder()
    .ConfigureWebHostDefaults(
        builder => builder.UseStartup<Startup>()
    );

var host = builder.Build();

await host.MigrateDatabase(CancellationToken.None);

host.Run();
