using System;

namespace TSM.Task.Application.Services.Tags.Models.Responses;

public record TagDto
{
	public Guid Id { get; init; }

	public string Name { get; init; }

	public string Description { get; init; }
}
