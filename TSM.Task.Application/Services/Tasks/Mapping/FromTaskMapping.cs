using System.Collections.Generic;
using AutoMapper;
using TSM.Task.Application.Services.Tasks.Models;
using TaskEntity = TSM.Task.Domain.Entities.Task;

namespace TSM.Task.Application.Services.Tasks.Mapping;

public static class FromTaskMapping
{
	public static List<ReadTaskResponse> ToResponse(this List<TaskEntity> tasks)
	{
		return ReadTaskResponseMapper<ReadTaskResponse>()
			.Map<List<ReadTaskResponse>>(tasks);
	}

	public static T ToResponse<T>(this TaskEntity task)
	{
		return ReadTaskResponseMapper<T>()
			.Map<T>(task);
	}

	private static IMapper ReadTaskResponseMapper<T>()
	{
		var config = new MapperConfiguration(
			config => config.CreateMap<TaskEntity, T>()
				.ForMember("Category", option => option.MapFrom(task => task.Category.Name))
				.ForMember("Priority", option => option.MapFrom(task => task.Priority.Name))
		);
		return new Mapper(config);
	}
}