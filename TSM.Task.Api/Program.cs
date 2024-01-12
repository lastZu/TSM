using TSM.Task.Infrastructure;

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
using (var tasksContext = new TasksContext(connectionString))
{
// 	var category = new Category
// 	{
// 		Name = "Warn"
// 	};
// 	Infrastructure.Task task = new Infrastructure.Task()
// 	{
// 		Title = "Fest",
// 		Comment = "new",
// 		Category = category
// 	};
// 	tasksContext.Categories.AddRange(category);
// 	tasksContext.Tasks.AddRange(task);
// 	tasksContext.SaveChanges();
// // }
// // using (var tasksContext = new Infrastructure.TasksContext(connectionString))
// // {
// 	var tasks = tasksContext.Tasks.ToList();
// 	Console.WriteLine("List:");
// 	foreach (var el in tasks)
// 	{
// 		Console.WriteLine(
// 			$"{el.Id}.{el.Title} - {el}"
// 		);
// 	}
}


app.MapGet("/", () => "Hello World!");

app.Run();

public class PostgreSettings
{
	public string ConnectionString { get; set; }
}