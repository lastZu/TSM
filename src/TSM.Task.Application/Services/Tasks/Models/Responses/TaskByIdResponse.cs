using System;
using TSM.Task.Application.Services.Categories;
using TSM.Task.Application.Services.Priorities;
using TSM.Task.Application.Services.Tags.Models.Responses;

namespace TSM.Task.Application.Services.Tasks.Models.Responses;

public class TaskByIdResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public DateTime? Deadline { get; set; }

    public string Comment { get; set; }

    public CategoryDto Category { get; set; }

    public PriorityDto Priority { get; set; }

    public TagDto Tag { get; set; }
}
