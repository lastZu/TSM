using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using TSM.Task.Application.Services.Tasks.Models;
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

	public CreateTaskResponcse Create(CreateTaskRerquest request)
	{
		if (request == null)
		{
			throw new ArgumentNullException();
		}

		var task = CreateTaskRerquest.ToEntity(request);
		var createdTask = _taskContext.Tasks.Add(task).Entity;
		createdTask.Category = _taskContext.Categories
			.Where(category => category.Id == createdTask.CategoryId)
			.FirstOrDefault();
		createdTask.Priority = _taskContext.Priorities
			.Where(priority => priority.Id == createdTask.PriorityId)
			.FirstOrDefault();
		return CreateTaskResponcse.Get(createdTask);
	}

	public void Delete(DeleteTaskRerquest request)
	{
		if (request == null)
		{
			throw new ArgumentNullException();
		}

		var task = GetByIdFromContext(request.Id);
		if (task == null)
		{
			throw new ArgumentOutOfRangeException("Task does not exists");
		}
		_taskContext.Tasks.Remove(task);
	}

	public ReadTaskResponcse GetById(ReadTaskRerquest request)
	{
		if (request == null)
		{
			throw new ArgumentNullException();
		}

		var task = GetByIdFromContext(request.Id);
		if (task == null)
		{
			return null;
		}
		return ReadTaskResponcse.Get(task);
	}

	public UpdateTaskResponcse Update(UpdateTaskRequest request)
	{
		if (request == null)
		{
			throw new ArgumentNullException();
		}

		var oldTask = GetByIdFromContext(request.Id);
		var task = UpdateTaskRequest.ToEntity(request, oldTask);
		if (task == null)
		{
			throw new ArgumentException("Task does not exists");
		}
		_taskContext.Tasks.Update(task);
		return UpdateTaskResponcse.Get(task);
	}

	public void Save()
	{
		_taskContext.SaveChanges();
	}

	private TaskEntity GetByIdFromContext(Guid id)
	{
		return _taskContext.Tasks
			.Include(task => task.Category)
			.Include(task => task.Priority)
			.Where(task => task.Id == id)
			.FirstOrDefault();
	}
}