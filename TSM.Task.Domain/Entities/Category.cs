namespace TSM.Task.Domain.Entities;

public class Category
{
	public int Id { get; set; }
	// TODO - change to enam?
	public required string Name { get; set; }
	public ICollection<Task> Tasks { get; } = new List<Task>();
}