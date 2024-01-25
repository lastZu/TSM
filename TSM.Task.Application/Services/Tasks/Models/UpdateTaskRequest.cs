using System;

using TaskEntity = TSM.Task.Domain.Entities.Task;

namespace TSM.Task.Application.Services.Tasks.Models;

public class UpdateTaskRequest
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public DateTime? Deadline { get; set; }
	public string Comment { get; set; }

	public byte? CategoryId { get; set; }

	public byte? PriorityId { get; set; }

	internal static TaskEntity ToEntity(
		UpdateTaskRequest request,
		TaskEntity oldTask)
	{
		return new TaskEntity
		{
			Id = request.Id,
			Title = DefaulIfEmpty(request.Title, oldTask.Title),
			Deadline = DefaulIfEmpty(request.Deadline, oldTask.Deadline),
			Comment = DefaulIfEmpty(request.Comment, oldTask.Comment),
			CategoryId = DefaulIfEmpty(request.CategoryId, oldTask.CategoryId),
			PriorityId = DefaulIfEmpty(request.PriorityId, oldTask.PriorityId),
		};

	}

	static T DefaulIfEmpty<T>(T value, T defaultValue)
	{
		return value == null ? defaultValue : value;
	}
}