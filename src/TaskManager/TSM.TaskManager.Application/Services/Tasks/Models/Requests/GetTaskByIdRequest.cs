using System;

namespace TSM.TaskManager.Application.Services.Tasks.Models.Requests;

public sealed record GetTaskByIdRequest
{
	public Guid Id { get; init; }
}
