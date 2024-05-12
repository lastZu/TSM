using System;

namespace TSM.Task.Application.Services.Tasks.Models.Requests;

public sealed record CreateTaskRequest
{
	public string Title { get; init; }

	public DateTime? Deadline { get; init; }

	public string Comment { get; init; }

	public byte? CategoryId { get; init; }

	public byte? PriorityId { get; init; }

	public Guid? TagId { get; init; }
}
