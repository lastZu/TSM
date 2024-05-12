using System;

namespace TSM.Task.Application.Services.Tasks.Models.Requests;

public sealed record DeleteTaskRequest
{
	public Guid Id { get; init; }
}
