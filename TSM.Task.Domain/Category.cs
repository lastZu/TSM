namespace TSM.TaskNS.Domain;

public class Category
{
	public int Id { get; set; }
	// TODO - change to enam?
	public required string Name { get; set; }
	public ICollection<Issue> Issues { get; } = new List<Issue>();
}
