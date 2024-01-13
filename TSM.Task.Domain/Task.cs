using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSM.Task.Domain;

public class Task
{
	public int Id { get; set; }
	public required string Title { get; set; }
	public DateTime Dedline { get; set; }
	public string? Comment { get; set; }

	public int CategoryId { get; set; }
	public required Category Category { get; set; }

	public int PriorityId { get; set; }
	public required Priority Priority { get; set; }
}
