using System;

using TaskEntity = TSM.Task.Domain.Entities.Task;

namespace TSM.Task.Application.Services.Tasks.Models;

public class CreateTaskRerquest
{
	public string Title { get; set; }
	public DateTime? Deadline { get; set; }
	public string Comment { get; set; }

	public byte? CategoryId { get; set; }

	public byte? PriorityId { get; set; }

	public static TaskEntity ToEntity(CreateTaskRerquest request)
	{
		if (!IsValidTitle(request.Title))
		{
			throw new ArgumentException("Title is not valid");
		}

		return new TaskEntity
		{
			Title = request.Title,
			Deadline = request.Deadline,
			Comment = request.Comment,
			CategoryId = request.CategoryId,
			PriorityId = request.PriorityId
		};
	}

	private static bool IsValidTitle(string title)
	{
		return !string.IsNullOrWhiteSpace(title);
	}
}