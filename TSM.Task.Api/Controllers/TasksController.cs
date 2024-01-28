using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using TSM.Task.Application.Services.Tasks;
using TSM.Task.Application.Services.Tasks.Models;

namespace TSM.Task.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
	private ITaskService _taskService;
	public TasksController(ITaskService taskService)
	{
		_taskService = taskService;
	}

	[HttpPost]
	public CreateTaskResponse Post()
	{
		var request = new CreateTaskRequest
		{
			Title = "Rest",
			Deadline = DateTime.Now,
			CategoryId = 1,
			PriorityId = 1
		};
		var response = _taskService.Create(request);
		_taskService.Save();
		return response;
	}

	[HttpGet]
	public List<ReadTaskResponse> GetAll()
	{
		return _taskService.GetAll();
	}

	[HttpGet("{id=Guid}")]
	public string FindTask(Guid id)
	{
		var request = new ReadTaskRerquest
		{
			Id =  id
		};
		var res = _taskService.GetById(request).ToString();
		_taskService.Save();
		return res;
	}

	[HttpPut]
	public UpdateTaskResponcse UpdateTask()
	{
		var request = new UpdateTaskRequest
		{
			Title = "name"
		};
		var response = _taskService.Update(request);
		_taskService.Save();
		return response;
	}

	[HttpDelete]
	public void DeleteTask(Guid id)
	{
		var request = new DeleteTaskRerquest
		{
			Id =  id
		};
		_taskService.Delete(request);
		_taskService.Save();
	}
}