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
using TSM.Task.Application.Models;

namespace TSM.Task.Application.Services.Tasks;

internal sealed class TaskService : ITaskService
{
	private const int DefaultPage = 1;

	private const int DefaultSize = 20;

	private readonly TaskContext _taskContext;

	private readonly DbSet<TaskEntity> _tasksSet;

	private readonly IMapper _mapper;

	public TaskService(TaskContext taskContext, IMapper mapper)
	{
		_taskContext = taskContext;
		_mapper = mapper;

		_tasksSet = _taskContext.Set<TaskEntity>();
	}

	public async Task<IReadOnlyList<TaskResponse>> GetAll(CancellationToken cancellationToken)
	{
		var tasks = await _tasksSet
			.AsNoTracking()
			.Include(task => task.Category)
			.Include(task => task.Priority)
			.Include(task => task.Tag)
			.ToListAsync(cancellationToken);

		return _mapper.Map<IReadOnlyList<TaskResponse>>(tasks);
	}

	public async Task<TaskByIdResponse> GetById(GetTaskByIdRequest request, CancellationToken cancellationToken)
	{
		var task = await _tasksSet
			.AsNoTracking()
			.Include(task => task.Category)
			.Include(task => task.Priority)
			.Include(task => task.Tag)
			.Where(task => task.Id == request.Id)
			.FirstOrDefaultAsync(cancellationToken);

		return _mapper.Map<TaskByIdResponse>(task);
	}
	public async Task<CreateTaskResponse> Create(CreateTaskRequest request, CancellationToken cancellationToken)
	{
		var task = _mapper.Map<TaskEntity>(request);

		await _tasksSet.AddAsync(task, cancellationToken);

		await _taskContext.SaveChangesAsync(cancellationToken);

		return _mapper.Map<CreateTaskResponse>(task);
	}

	public async Task<PagedList<SearchTaskResponse>> Search(SearchTasksRequest request, CancellationToken cancellationToken)
	{
		var categoriesIsEmpty = request.Categories is null;
		var prioritiesIsEmpty = request.Priorities is null;
		var tagsIsEmpty = request.Tags is null;
		var deadlineByIsEmpty = request.DeadlineBy is null;

		var tasks = _tasksSet
			.AsNoTracking()
			.Include(task => task.Category)
			.Include(task => task.Priority)
			.Include(task => task.Tag)
			.Where(task => categoriesIsEmpty || request.Categories.Contains(task.CategoryId))
			.Where(task => prioritiesIsEmpty || request.Priorities.Contains(task.PriorityId))
			.Where(task => tagsIsEmpty || request.Tags.Contains(task.TagId))
			.Where(task => deadlineByIsEmpty || task.Deadline <= request.DeadlineBy);

		var countTask = tasks.CountAsync(cancellationToken);

		var size = request.Size ?? DefaultSize;
		var page = request.Page ?? DefaultPage;

		var linesToSkip = (page - 1) * size;

		var chankTask = tasks
			.Skip(linesToSkip)
			.Take(size)
			.ToArrayAsync(cancellationToken);

		await System.Threading.Tasks.Task.WhenAll(countTask, chankTask);

		var totalCount = countTask.Result;
		var chank = chankTask.Result;

		var items = _mapper.Map<SearchTaskResponse[]>(chank);

		return new PagedList<SearchTaskResponse>
		{
			Items = items,
			Page = page,
			Size = size,
			TotalCount = totalCount,
		};
	}

	public async Task<UpdateTaskResponse> Update(UpdateTaskRequest request, CancellationToken cancellationToken)
	{
		var task = await _tasksSet
			.Include(t => t.Category)
			.Include(t => t.Priority)
			.Include(t => t.Tag)
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

	public async System.Threading.Tasks.Task Delete(DeleteTaskRequest request, CancellationToken cancellationToken)
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
