using System;

namespace TSM.Task.Domain.Entities;

public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime? Deadline { get; set; }
    public string Comment { get; set; }

    public byte? CategoryId { get; set; }
    public Category Category { get; set; }

    public byte? PriorityId { get; set; }
    public Priority Priority { get; set; }

    public Guid? TagId { get; set; }
    public Tag Tag { get; set; }
}
