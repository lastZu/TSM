using System;

namespace TSM.TaskManager.Application.Services.Tasks.Models.Requests;

public sealed record DeleteTaskRequest
{
	public Guid Id { get; init; }
}
