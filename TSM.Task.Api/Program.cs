using System;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using TSM.Task.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

var postgreSettings = builder
	.Configuration
	.GetSection("postgre")
	.Get<PostgreSettings>();

var	connectionString = postgreSettings?.ConnectionString;
if (connectionString is null)
{
	throw new NullReferenceException("Connection string not specified");
}

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.MigrateDatabase(CancellationToken.None);

app.Run();

public class PostgreSettings
{
	public string ConnectionString { get; set; }
}