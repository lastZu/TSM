using System;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TSM.Task.Api;
using TSM.Task.Infrastructure.Extensions;

// var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddInfrastructureReferences("conectionString");
// var app = builder.Build();
// app.MapGet("/", () => "Hello World!");
// app.MigrateDatabase(CancellationToken.None);
// app.Run();

var builder = Host
	.CreateDefaultBuilder()
	.ConfigureWebHostDefaults(
		builder => builder.UseStartup<Startup>()
	);

var host = builder.Build();
host.MigrateDatabase(CancellationToken.None);
host.Run();

// builder.Host.ConfigureWebHostDefaults( //.WebHost.ConfigureServices(
// 	hostBuilder => hostBuilder.UseStartup<Startup>()
// );
// var startup = new Startup(builder.Configuration);
// startup.ConfigureServices(builder.Services);
