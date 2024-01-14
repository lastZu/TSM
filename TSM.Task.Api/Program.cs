using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using TSM.Task.Infrastructure;
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
using (var context = new TaskContext())
{}

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();

public class PostgreSettings
{
	public string ConnectionString { get; set; }
}