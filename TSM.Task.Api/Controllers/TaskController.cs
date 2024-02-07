using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TSM.Task.Application.Services.Tasks;
using TSM.Task.Application.Services.Tasks.Models;

namespace TSM.Task.Api.Controllers;

[ApiController]
[Route("tasks")]
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

    [HttpGet("{id:guid}")]
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

    [HttpPut("{id:guid}")]
    public async Task<UpdateTaskResponse> Update(UpdateTaskRequest request)
    {
        return await _taskService.Update(request);
    }

    [HttpDelete("{id:guid}")]
    public async void Delete(Guid id)
    {
        var request = new DeleteTaskRequest
        {
            Id = id
        };

        await System.Threading.Tasks.Task.Run(
            () => _taskService.Delete(request)
        );
    }
}