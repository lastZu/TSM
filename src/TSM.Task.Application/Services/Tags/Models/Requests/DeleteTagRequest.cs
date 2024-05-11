using System;

namespace TSM.Task.Application.Services.Tags.Models.Requests;

public sealed record DeleteTagRequest
{
	public Guid Id { get; init; }
}
