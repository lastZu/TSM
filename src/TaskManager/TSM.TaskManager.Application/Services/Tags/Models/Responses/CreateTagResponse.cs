using System;

namespace TSM.TaskManager.Application.Services.Tags.Models.Responses;

public record CreateTagResponse
{
	public Guid Id { get; init; }

	public string Name { get; init; }

	public string Description { get; init; }
}
