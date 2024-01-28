using AutoMapper;
using TSM.Task.Application.Services.Tasks.Models;
using TaskEntity = TSM.Task.Domain.Entities.Task;

namespace TSM.Task.Application.Services.Tasks.Mapping;

public static class ToTaskMapping
{
	public static TaskEntity ToTask(this CreateTaskRequest request)
	{
		var config = new MapperConfiguration(
			config => config.CreateMap<CreateTaskRequest, TaskEntity>()
		);
		var mapper = new Mapper(config);
		return mapper.Map<TaskEntity>(request);
	}

	public static TaskEntity ToTask(this UpdateTaskRequest request)
	{
		var config = new MapperConfiguration(
			config => config.CreateMap<UpdateTaskRequest, TaskEntity>()
		);
		var mapper = new Mapper(config);
		return mapper.Map<TaskEntity>(request);
	}
}