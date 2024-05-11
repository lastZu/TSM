using System;

namespace TSM.Task.Application.Services.Tags.Models.Requests;

public sealed record UpdateTagRequest
{
	public Guid Id { get; init; }

	public string Name { get; init; }

	public string Description { get; init; }
}
