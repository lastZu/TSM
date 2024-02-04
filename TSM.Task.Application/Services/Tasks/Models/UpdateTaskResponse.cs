using System;

namespace TSM.Task.Application.Services.Tasks.Models;

public class UpdateTaskResponse
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public DateTime? Deadline { get; set; }
	public string Comment { get; set; }

	public string Category { get; set; }

	public string Priority { get; set; }
}
