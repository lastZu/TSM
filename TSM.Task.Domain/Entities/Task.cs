using System;

namespace TSM.Task.Domain.Entities;

public class Task
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public DateTime? Dedline { get; set; }
	public string? Comment { get; set; }

	public int CategoryId { get; set; }
	public Category? Category { get; set; }

	public int PriorityId { get; set; }
	public Priority? Priority { get; set; }
}