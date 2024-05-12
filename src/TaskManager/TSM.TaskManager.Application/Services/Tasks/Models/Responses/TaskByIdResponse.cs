using System;
using TSM.TaskManager.Application.Services.Categories;
using TSM.TaskManager.Application.Services.Priorities;
using TSM.TaskManager.Application.Services.Tags.Models.Responses;

namespace TSM.TaskManager.Application.Services.Tasks.Models.Responses;

public sealed record TaskByIdResponse
{
	public Guid Id { get; init; }

	public string Title { get; init; }

	public DateTime? Deadline { get; init; }

	public string Comment { get; init; }

	public CategoryDto Category { get; init; }

	public PriorityDto Priority { get; init; }

	public TagDto Tag { get; init; }
}
