using System;

namespace TSM.Task.Application.Services.Tasks.Models.Responses;

public sealed class UpdateTaskResponse
{
	public Guid Id { get; set; }

	public string Title { get; set; }

	public DateTime? Deadline { get; set; }

	public string Comment { get; set; }

	public string Category { get; set; }

	public string Priority { get; set; }

	public string Tag { get; set; }
}
