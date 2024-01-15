using System;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using TSM.Task.Api;
using TSM.Task.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.MigrateDatabase(CancellationToken.None);

app.Run();
