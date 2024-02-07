using System;

namespace TSM.Task.Application.Services.Tasks.Models;

public class CreateTaskRequest
{
	public string Title { get; set; }

	public DateTime? Deadline { get; set; }

	public string Comment { get; set; }

	public byte? CategoryId { get; set; }

	public byte? PriorityId { get; set; }
}