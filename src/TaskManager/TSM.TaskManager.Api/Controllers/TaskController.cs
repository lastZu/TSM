using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSM.TaskManager.Application.Models;
using TSM.TaskManager.Application.Services.Tasks;
using TSM.TaskManager.Application.Services.Tasks.Models.Requests;
using TSM.TaskManager.Application.Services.Tasks.Models.Responses;

namespace TSM.TaskManager.Api.Controllers;

[ApiController]
[Route("tasks")]
public sealed class TaskController : ControllerBase
{
	private readonly ITaskService _taskService;

	public TaskController(ITaskService taskService)
	{
		_taskService = taskService;
	}

	[HttpGet]
	public async Task<IReadOnlyList<TaskResponse>> GetAll(CancellationToken cancellationToken)
	{
		return await _taskService.GetAll(cancellationToken);
	}

	[HttpGet("{id:guid}")]
	public async Task<TaskByIdResponse> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
	{
		var request = new GetTaskByIdRequest
		{
			Id = id
		};

		return await _taskService.GetById(request, cancellationToken);
	}

	[HttpPost]
	public async Task<CreateTaskResponse> Create([FromBody] CreateTaskRequest request, CancellationToken cancellationToken)
	{
		return await _taskService.Create(request, cancellationToken);
	}

	[HttpPost("search")]
	public async Task<PagedList<SearchTaskResponse>> Search([FromBody] SearchTasksRequest request, CancellationToken cancellationToken)
	{
		return await _taskService.Search(request, cancellationToken);
	}

	[HttpPut]
	public async Task<UpdateTaskResponse> Update(
		[FromBody] UpdateTaskRequest request,
		CancellationToken cancellationToken)
	{
		return await _taskService.Update(request, cancellationToken);
	}

	[HttpDelete("{id:guid}")]
	public async Task Delete([FromRoute] Guid id, CancellationToken cancellationToken)
	{
		var request = new DeleteTaskRequest
		{
			Id = id
		};

		await _taskService.Delete(request, cancellationToken);
	}
}
