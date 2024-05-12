using System;

namespace TSM.Task.Application.Services.Tasks.Models.Responses;

public sealed record SearchTaskResponse
{
	public Guid Id { get; init; }

	public string Title { get; init; }

	public DateTime? Deadline { get; init; }

	public string Comment { get; init; }

	public string Category { get; init; }

	public string Priority { get; init; }

	public string Tag { get; init; }
}
