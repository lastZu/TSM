using System;

namespace TSM.Task.Application.Services.Tasks.Models.Requests;

public sealed class DeleteTaskRequest
{
	public Guid Id { get; set; }
}
