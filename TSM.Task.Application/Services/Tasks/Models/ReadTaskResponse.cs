using System;

namespace TSM.Task.Application.Services.Tasks.Models;

public class ReadTaskResponse
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public DateTime? Deadline { get; set; }
	public string Comment { get; set; }

	public byte? CategoryId { get; set; }
	public string Category { get; set; }

	public byte? PriorityId { get; set; }
	public string Priority { get; set; }
}
