namespace TSM.TaskNS.Domain;

public class Priority
{
	public int Id { get; set; }
	// TODO - change to enam?
	public required string Name { get; set; }
	public ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
