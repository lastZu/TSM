using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSM.Task.Application.Services.Tasks;
using TSM.Task.Application.Services.Tasks.Models.Requests;
using TSM.Task.Application.Services.Tasks.Models.Responses;

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
    public async Task<List<TaskResponse>> GetAll(CancellationToken cancellationToken)
    {
        return await _taskService.GetAll(cancellationToken);
    }

    [HttpGet("{id:guid}")]
    public async Task<TaskByIdResponse> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetTaskByIdRequest
        {
            Id =  id
        };

        return await _taskService.GetById(request, cancellationToken);
    }

    [HttpPost]
    public async Task<CreateTaskResponse> Create([FromBody] CreateTaskRequest request, CancellationToken cancellationToken)
    {
        return await _taskService.Create(request, cancellationToken);
    }

    [HttpPut("{id:guid}")]
    public async Task<UpdateTaskResponse> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateTaskRequest request,
        CancellationToken cancellationToken)
    {
        request.Id = id;

        return await _taskService.Update(request, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    public async System.Threading.Tasks.Task Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteTaskRequest
        {
            Id = id
        };

        await System.Threading.Tasks.Task.Run(
            () => _taskService.Delete(request, cancellationToken),
            cancellationToken
        );
    }
}