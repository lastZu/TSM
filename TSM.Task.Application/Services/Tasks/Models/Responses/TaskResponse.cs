using System;
using TSM.Task.Application.Services.Categories;
using TSM.Task.Application.Services.Priorities;
using TSM.Task.Application.Services.Tags.Models.Responses;

namespace TSM.Task.Application.Services.Tasks.Models.Responses;

public class TaskResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public DateTime? Deadline { get; set; }

    public string Comment { get; set; }

    public CategoryDto CategoryResponse { get; set; }

    public PriorityDto PriorityResponse { get; set; }

    public TagDto TagResponse { get; set; }
}
