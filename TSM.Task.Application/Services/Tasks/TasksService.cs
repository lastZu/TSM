using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TSM.Task.Application.Services.Tasks.Models;
using TSM.Task.Application.Services.Tasks.Mapping;
using TSM.Task.Infrastructure;
using TaskEntity = TSM.Task.Domain.Entities.Task;

namespace TSM.Task.Application.Services.Tasks;

public class TasksService : ITaskService
{
    private readonly TaskContext _taskContext;
    private readonly DbSet<TaskEntity> _tasksSet;

    public TasksService(TaskContext taskContext)
    {
        _taskContext = taskContext;
        _tasksSet = _taskContext.Set<TaskEntity>();
    }

    public async Task<List<GetTaskByIdResponse>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _tasksSet
            .AsNoTracking()
            .Include(task => task.Category)
            .Include(task => task.Priority)
            .Select(task => task.ToResponse())
            .ToListAsync(cancellationToken);
    }

    public async Task<GetTaskByIdResponse> GetById(GetTaskByIdRequest request, CancellationToken cancellationToken = default)
    {
        return await _tasksSet
            .AsNoTracking()
            .Include(task => task.Category)
            .Include(task => task.Priority)
            .Where(task => task.Id == request.Id)
            .Select(task => task.ToResponse())
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<CreateTaskResponse> Create(CreateTaskRequest request, CancellationToken cancellationToken = default)
    {
        var task = request.ToTask();

        await _tasksSet.AddAsync(task, cancellationToken);

        await _taskContext.SaveChangesAsync(cancellationToken);

        return task.ToResponse<CreateTaskResponse>();
    }

    public async Task<UpdateTaskResponse> Update(UpdateTaskRequest request, CancellationToken cancellationToken = default)
    {
        var task = await _tasksSet
            .Where(t => t.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        task.Title = request.Title;
        task.Comment = request.Comment;
        task.Deadline = request.Deadline;
        task.CategoryId = request.CategoryId;
        task.PriorityId = request.PriorityId;

        await _taskContext.SaveChangesAsync(cancellationToken);

        return task.ToResponse<UpdateTaskResponse>();
    }

    public async Task<bool> Delete(DeleteTaskRequest request, CancellationToken cancellationToken = default)
    {
        var task = await _taskContext.Tasks
            .AsNoTracking()
            .Where(task => task.Id == request.Id)
            .FirstOrDefaultAsync();

        if (task is null)
        {
            throw new ArgumentOutOfRangeException($"Task with id - {request.Id} does not exists");
        }

        _taskContext.Tasks.Remove(task);

        await _taskContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}