using System;

namespace TSM.TaskManager.Application.Services.Tags.Models.Requests;

public sealed record CreateTagRequest
{
	public Guid Id { get; init; }

	public string Name { get; init; }

	public string Description { get; init; }
}