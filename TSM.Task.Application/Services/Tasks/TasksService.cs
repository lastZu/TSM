using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
	private readonly IMapper _mapper;

	public TasksService(TaskContext taskContext, IMapper mapper)
	{
		_taskContext = taskContext;
		_mapper = mapper;
		
		_tasks = _taskContext.Set<TaskEntity>();
	}

	public async Task<CreateTaskResponse> Create(CreateTaskRequest request, CancellationToken cancellationToken = default)
	{
		var task = _mapper.Map<TaskEntity>(request);

		await _tasks.AddAsync(task, cancellationToken);

		await _taskContext.SaveChangesAsync(cancellationToken);

		return _mapper.Map<CreateTaskResponse>(task);
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

	public async Task<UpdateTaskResponse> Update(UpdateTaskRequest request, CancellationToken cancellationToken = default)
	{
		var task = await _tasks
			.Where(t => t.Id == request.Id)
			.FirstOrDefaultAsync(cancellationToken);

		if (task is null)
		{
			throw new ApplicationException($"Task {request.Id} is not found");
		}

		_mapper.Map(request, task);

		_tasks.Update(task);

		await _taskContext.SaveChangesAsync(cancellationToken);

		return _mapper.Map<UpdateTaskResponse>(task);
	}

	public async void Delete(DeleteTaskRequest request, CancellationToken cancellationToken = default)
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
			.FirstOrDefault(func);

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