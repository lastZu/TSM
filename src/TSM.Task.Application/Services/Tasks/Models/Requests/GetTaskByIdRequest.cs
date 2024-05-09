using System;

namespace TSM.Task.Application.Services.Tasks.Models.Requests;

public sealed class GetTaskByIdRequest
{
	public Guid Id { get; set; }
}
