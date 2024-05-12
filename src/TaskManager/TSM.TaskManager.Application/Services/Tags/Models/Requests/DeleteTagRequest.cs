using System;

namespace TSM.TaskManager.Application.Services.Tags.Models.Requests;

public sealed record DeleteTagRequest
{
	public Guid Id { get; init; }
}
