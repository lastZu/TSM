namespace TSM.Task.Domain;

public class Priority
{
	public int Id { get; set; }
	// TODO - change to enam?
	public required string Name { get; set; }
	public ICollection<Task> Tasks { get; set; } = new List<Task>();
}
