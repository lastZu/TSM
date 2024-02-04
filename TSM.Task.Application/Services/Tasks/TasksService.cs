using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TSM.Task.Application.Services.Tasks.Models;
using TSM.Task.Application.Services.Tasks.Mapping;
using TSM.Task.Domain.Entities;
using TSM.Task.Infrastructure;
using TaskEntity = TSM.Task.Domain.Entities.Task;

namespace TSM.Task.Application.Services.Tasks;

public class TasksService : ITaskService
{
	private readonly TaskContext _taskContext;
	private readonly DbSet<TaskEntity> _tasks;

	public TasksService(TaskContext taskContext)
	{
		_taskContext = taskContext;
		_tasks = _taskContext.Set<TaskEntity>();
	}

	public async Task<CreateTaskResponse> Create(CreateTaskRequest request, CancellationToken cancellationToken = default)
	{
		var task = request.ToTask();
		if (!IsValidCategoryId(task.CategoryId))
		{
			throw new ArgumentNullException($"Category id - {task.CategoryId} not exist");
		}
		if (!IsValidPriorityId(task.PriorityId))
		{
			throw new ArgumentNullException($"Priority id - {task.PriorityId} not exist");
		}

		var entry = await _tasks
			.AddAsync(task, cancellationToken);

		Save(cancellationToken);

		return entry.Entity.ToResponse<CreateTaskResponse>();
	}

	public async Task<List<GetTaskByIdResponse>> GetAll(CancellationToken cancellationToken = default)
	{
		return await _tasks
			.AsNoTracking()
			.Include(task => task.Category)
			.Include(task => task.Priority)
			.Select(task => task.ToResponse<GetTaskByIdResponse>())
			.ToListAsync(cancellationToken);
	}

	public async Task<GetTaskByIdResponse> GetById(GetTaskByIdRequest request, CancellationToken cancellationToken = default)
	{
		return await _tasks
			.AsNoTracking()
			.Include(task => task.Category)
			.Include(task => task.Priority)
			.Where(task => task.Id == request.Id)
			.Select(task => task.ToResponse<GetTaskByIdResponse>())
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<UpdateTaskResponse> Update(UpdateTaskRequest request, CancellationToken cancellationToken)
	{
		if (!IsValidCategoryId(request.CategoryId))
		{
			throw new ArgumentNullException($"Category id - {request.CategoryId} not exist");
		}
		if (!IsValidPriorityId(request.PriorityId))
		{
			throw new ArgumentNullException($"Priority id - {request.PriorityId} not exist");
		}

		var task = await _tasks
			.Where(t => t.Id == request.Id)
			.FirstOrDefaultAsync(cancellationToken);

		task.Title = request.Title;
		task.Comment = request.Comment;
		task.Deadline = request.Deadline;
		task.CategoryId = request.CategoryId;
		task.PriorityId = request.PriorityId;

		Save(cancellationToken);

		return task.ToResponse<UpdateTaskResponse>();
	}

	public async void Delete(DeleteTaskRequest request, CancellationToken cancellationToken)
	{
		var task = await _taskContext.Tasks
			.AsNoTracking()
			.Where(task => task.Id == request.Id)
			.FirstOrDefaultAsync();
		if (task is null)
		{
			throw new ArgumentOutOfRangeException("Task does not exists");
		}

		_taskContext.Tasks.Remove(task);

		Save(cancellationToken);
	}

	private void Save(CancellationToken cancellationToken)
	{
		_taskContext.SaveChangesAsync(cancellationToken);
	}

	private bool IsValidId<TEntity>(Func<TEntity, bool> func) where TEntity : class
	{
		var entity = _taskContext.Set<TEntity>()
			.Where(func)
			.FirstOrDefault();
		return entity is not null;
	}

	private bool IsValidCategoryId(byte? id)
	{
		if (id is null)
		{
			return false;
		}
		return IsValidId<Category>(category => category.Id == id);
	}

	private bool IsValidPriorityId(byte? id)
	{
		if (id is null)
		{
			return false;
		}
		return IsValidId<Priority>(priopity => priopity.Id == id);
	}
}