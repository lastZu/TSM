using System.ComponentModel.DataAnnotations;

namespace TSM.TaskNS.Infrastructure;

public class Task
{
	public int Id { get; set; }
	public required string Title { get; set; }
	public int PriorityId { get; set; }
	public DateTime Dedline { get; set; }
	public string? Comment { get; set; }

	public int CategoryId { get; set; }

	public Category Category { get; set; }
}
