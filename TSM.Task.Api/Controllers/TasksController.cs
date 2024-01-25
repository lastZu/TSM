using System;
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
	public string Post()
	{
		var request = new CreateTaskRerquest
		{
			Title = "Rest",
			Deadline = DateTime.Now,
			CategoryId = 1,
			PriorityId = 1
		};
		var response = _taskService.Create(request);
		_taskService.Save();
		return response.ToString();
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
	public string UpdateTask(Guid id, string name)
	{
		var request = new UpdateTaskRequest
		{
			Id = id,
			Title = name
		};
		var res = _taskService.Update(request).ToString();
		_taskService.Save();
		return res;
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