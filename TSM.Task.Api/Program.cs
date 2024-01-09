using Infrastructure = TSM.TaskNS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var postgreSettings = builder
	.Configuration
	.GetSection("postgre")
	.Get<PostgreSettings>();
var	connectionString = postgreSettings?.ConnectionString;
if (connectionString is null)
{
	throw new NullReferenceException("Connection string not specified");
}
using (var tasksContext = new Infrastructure.TasksContext(connectionString))
{
	var tasks = tasksContext.Tasks.ToList();
	Console.WriteLine("List:");
	foreach (var task in tasks)
	{
		Console.WriteLine(
			$"{task.Id}.{task.Title} - {task.CategoryId}"
		);
	}
}


app.MapGet("/", () => "Hello World!");

app.Run();


public class PostgreSettings
{
	public string ConnectionString { get; set; }
}