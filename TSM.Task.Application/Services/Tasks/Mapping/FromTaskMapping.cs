using System.Collections.Generic;
using AutoMapper;
using TSM.Task.Application.Services.Tasks.Models;
using TaskEntity = TSM.Task.Domain.Entities.Task;

namespace TSM.Task.Application.Services.Tasks.Mapping;

public static class FromTaskMapping
{
	public static GetTaskByIdResponse ToResponse(this TaskEntity task)
	{
		var category = new CategoryDto
		{
			Id = task.CategoryId,
			Name = task.Category.Name,
		};

		var priority = new PriorityDto
		{
			Id = task.PriorityId,
			Name = task.Priority.Name,
		};

		return new GetTaskByIdResponse
		{
			Id = task.Id,
			Title = task.Title,
			Deadline = task.Deadline,
			Comment = task.Comment,
			Category = category,
			Priority = priority,
		};
	}
	public static T ToResponse<T>(this TaskEntity task)
	{
		return TaskResponseMapper<T>()
			.Map<T>(task);
	}

	private static IMapper TaskResponseMapper<T>()
	{
		var config = new MapperConfiguration(
			config => config.CreateMap<TaskEntity, T>()
				.ForMember("Category", option => option.MapFrom(task => task.Category.Name))
				.ForMember("Priority", option => option.MapFrom(task => task.Priority.Name))
		);
		return new Mapper(config);
	}
}