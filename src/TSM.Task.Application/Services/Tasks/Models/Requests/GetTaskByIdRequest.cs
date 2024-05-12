using System;

namespace TSM.Task.Application.Services.Tasks.Models.Requests;

public sealed record GetTaskByIdRequest
{
	public Guid Id { get; init; }
}
