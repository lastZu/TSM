using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TSM.Task.Application.Services.Tasks.Models.Requests;
using TSM.Task.Application.Services.Tasks.Models.Responses;
using TSM.Task.Infrastructure;
using TaskEntity = TSM.Task.Domain.Entities.Task;

namespace TSM.Task.Application.Services.Tasks;

public class TasksService : ITaskService
{
    private readonly TaskContext _taskContext;
    private readonly DbSet<TaskEntity> _tasksSet;
    private readonly IMapper _mapper;

    public TasksService(TaskContext taskContext, IMapper mapper)
    {
        _taskContext = taskContext;
        _mapper = mapper;

        _tasksSet = _taskContext.Set<TaskEntity>();
    }

    public async Task<CreateTaskResponse> Create(CreateTaskRequest request, CancellationToken cancellationToken = default)
    {
        var task = _mapper.Map<TaskEntity>(request);

        await _tasksSet.AddAsync(task, cancellationToken);

        await _taskContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CreateTaskResponse>(task);
    }

    public async Task<List<TaskResponse>> GetAll(CancellationToken cancellationToken = default)
    {
        var tasks = await _tasksSet
            .AsNoTracking()
            .Include(task => task.Category)
            .Include(task => task.Priority)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<TaskResponse>>(tasks);
    }

    public async Task<TaskByIdResponse> GetById(GetTaskByIdRequest request, CancellationToken cancellationToken = default)
    {
        var task = await _tasksSet
            .AsNoTracking()
            .Include(task => task.Category)
            .Include(task => task.Priority)
            .Where(task => task.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        return _mapper.Map<TaskByIdResponse>(task);
    }

    public async Task<UpdateTaskResponse> Update(UpdateTaskRequest request, CancellationToken cancellationToken = default)
    {
        var task = await _tasksSet
            .Where(t => t.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (task is null)
        {
            throw new ArgumentOutOfRangeException($"Task {request.Id} is not found");
        }

        _mapper.Map(request, task);

        _tasksSet.Update(task);

        await _taskContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UpdateTaskResponse>(task);
    }

    public async System.Threading.Tasks.Task Delete(DeleteTaskRequest request, CancellationToken cancellationToken = default)
    {
        var task = await _tasksSet
            .Where(task => task.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (task is null)
        {
            throw new ArgumentOutOfRangeException($"Task with id - {request.Id} does not exists");
        }

        _tasksSet.Remove(task);

        await _taskContext.SaveChangesAsync(cancellationToken);
    }
}