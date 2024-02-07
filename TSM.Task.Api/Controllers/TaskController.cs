using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TSM.Task.Application.Services.Tasks;
using TSM.Task.Application.Services.Tasks.Models;

namespace TSM.Task.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
	private readonly ITaskService _taskService;

	public TaskController(ITaskService taskService)
	{
		_taskService = taskService;
	}

	[HttpGet]
	public async Task<List<GetTaskByIdResponse>> GetAll()
	{
		return await _taskService.GetAll();
	}

	[HttpGet("{id:Guid}")]
	public async Task<GetTaskByIdResponse> GetById(Guid id)
	{
		var request = new GetTaskByIdRequest
		{
			Id =  id
		};
		return await _taskService.GetById(request);
	}

	[HttpPost]
	public async Task<CreateTaskResponse> Create(CreateTaskRequest request)
	{
		return await _taskService.Create(request);
	}

	[HttpPut]
	public async Task<UpdateTaskResponse> Update(UpdateTaskRequest request)
	{
		return await _taskService.Update(request);
	}

	[HttpDelete]
	public void Delete(DeleteTaskRequest request)
	{
		_taskService.Delete(request);
	}
}