using System;

using TaskEntity = TSM.Task.Domain.Entities.Task;

namespace TSM.Task.Application.Services.Tasks.Models;

public class CreateTaskResponcse
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public DateTime? Deadline { get; set; }
	public string Comment { get; set; }

	public byte? CategoryId { get; set; }
	public string Category { get; set; }

	public byte? PriorityId { get; set; }
	public string Priority { get; set; }

	internal static CreateTaskResponcse Get(TaskEntity task)
	{
		return new CreateTaskResponcse
		{
			Id = task.Id,
			Title = task.Title,
			Deadline = task.Deadline,
			Comment = task.Comment,
			CategoryId = task.CategoryId,
			Category = task.Category.Name,
			PriorityId = task.PriorityId,
			Priority = task.Priority.Name
		};
	}

    public override string ToString()
    {
        return $"Title = {Title}";
    }
}
