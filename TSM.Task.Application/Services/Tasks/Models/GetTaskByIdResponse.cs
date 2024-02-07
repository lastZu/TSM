using System;

namespace TSM.Task.Application.Services.Tasks.Models;

public class GetTaskByIdResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public DateTime? Deadline { get; set; }

    public string Comment { get; set; }

    public CategoryDto Category { get; set; }

    public PriorityDto Priority { get; set; }
}

public class CategoryDto
{
    public byte? Id { get; set; }

    public string Name { get; set; }
}

public class PriorityDto
{
    public byte? Id { get; set; }

    public string Name { get; set; }
}