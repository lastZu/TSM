using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using TSM.Task.Application.Services.Tasks.Models;
using TSM.Task.Application.Services.Tasks.Mapping;
using TSM.Task.Domain.Entities;
using TSM.Task.Infrastructure;
using TaskEntity = TSM.Task.Domain.Entities.Task;

namespace TSM.Task.Application.Services.Tasks;

public class TasksService : ITaskService
{
	private readonly TaskContext _taskContext;

	public TasksService(TaskContext taskContext)
	{
		_taskContext = taskContext;
	}

	public CreateTaskResponse Create(CreateTaskRequest request)
	{
		if (request == null)
		{
			throw new ArgumentNullException();
		}

		var task = request.ToTask();
		if (!IsValidCategoryId(task.CategoryId))
		{
			throw new ArgumentNullException($"Category id - {task.CategoryId} not exist");
		}
		if (!IsValidPriorityId(task.PriorityId))
		{
			throw new ArgumentNullException($"Priority id - {task.PriorityId} not exist");
		}

		_taskContext.Tasks.Add(task);
		return task.ToResponse<CreateTaskResponse>();
	}

	public void Delete(DeleteTaskRerquest request)
	{
		if (request == null)
		{
			throw new ArgumentNullException();
		}

		var task = GetByIdFromContext(request.Id).FirstOrDefault();
		if (task == null)
		{
			throw new ArgumentOutOfRangeException("Task does not exists");
		}
		_taskContext.Tasks.Remove(task);
	}

	public List<ReadTaskResponse> GetAll()
	{
		var tasks = _taskContext.Tasks
			.Include(tast => tast.Category)
			.Include(task => task.Priority)
			.ToList();
		return tasks.ToResponse();
	}

	public ReadTaskResponse GetById(ReadTaskRerquest request)
	{
		if (request == null)
		{
			throw new ArgumentNullException();
		}

		var task = GetByIdFromContext(request.Id)
			.AsNoTracking()
			.FirstOrDefault();
		if (task == null)
		{
			return null;
		}
		return task.ToResponse<ReadTaskResponse>();
	}

	public UpdateTaskResponcse Update(UpdateTaskRequest request)
	{
		if (request == null)
		{
			throw new ArgumentNullException();
		}
		if (!IsValidCategoryId(request.CategoryId))
		{
			throw new ArgumentNullException($"Category id - {request.CategoryId} not exist");
		}
		if (!IsValidPriorityId(request.PriorityId))
		{
			throw new ArgumentNullException($"Priority id - {request.PriorityId} not exist");
		}

		var task = request.ToTask();
		_taskContext.Tasks.Update(task);
		return task.ToResponse<UpdateTaskResponcse>();
	}

	public void Save()
	{
		_taskContext.SaveChanges();
	}

	private IQueryable<TaskEntity> GetByIdFromContext(Guid id)
	{
		return _taskContext.Tasks
			.Include(task => task.Category)
			.Include(task => task.Priority)
			.Where(task => task.Id == id);
	}

	private bool IsValidId<TEntity>(Func<TEntity, bool> func) where TEntity : class
	{
		var entity = _taskContext.Set<TEntity>()
			.Where(func)
			.FirstOrDefault();
		return entity != null;
	}

	private bool IsValidCategoryId(byte? id)
	{
		if (id == null)
		{
			return false;
		}
		return IsValidId<Category>(category => category.Id == id);
	}

	private bool IsValidPriorityId(byte? id)
	{
		if (id == null)
		{
			return false;
		}
		return IsValidId<Priority>(priopity => priopity.Id == id);
	}
}