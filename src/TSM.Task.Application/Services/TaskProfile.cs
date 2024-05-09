using AutoMapper;
using TSM.Task.Application.Services.Tasks.Models.Requests;
using TSM.Task.Application.Services.Tasks.Models.Responses;

namespace TSM.Task.Application.Services;

internal sealed class TaskProfile : Profile
{
	public TaskProfile()
	{
		MapTask();
		MapById();
		MapCreate();
		MapUpdate();
		MapSearch();
	}

	private void MapTask()
	{
		CreateMap<Domain.Entities.Task, TaskResponse>();
	}

	private void MapById()
	{
		CreateMap<Domain.Entities.Task, TaskByIdResponse>();
	}

	private void MapCreate()
	{
		CreateMap<CreateTaskRequest, Domain.Entities.Task>();

		CreateMap<Domain.Entities.Task, CreateTaskResponse>()
			.ForMember(dest => dest.Category, option => option.MapFrom(src => src.Category.Name))
			.ForMember(dest => dest.Priority, option => option.MapFrom(src => src.Priority.Name))
			.ForMember(dest => dest.Tag, option => option.MapFrom(src => src.Tag.Name));
	}

	private void MapUpdate()
	{
		CreateMap<UpdateTaskRequest, Domain.Entities.Task>();

		CreateMap<Domain.Entities.Task, UpdateTaskResponse>()
			.ForMember(dest => dest.Category, option => option.MapFrom(src => src.Category.Name))
			.ForMember(dest => dest.Priority, option => option.MapFrom(src => src.Priority.Name))
			.ForMember(dest => dest.Tag, option => option.MapFrom(src => src.Tag.Name));
	}

	private void MapSearch()
	{
		CreateMap<Domain.Entities.Task, SearchTaskResponse>()
			.ForMember(dest => dest.Category, option => option.MapFrom(src => src.Category.Name))
			.ForMember(dest => dest.Priority, option => option.MapFrom(src => src.Priority.Name))
			.ForMember(dest => dest.Tag, option => option.MapFrom(src => src.Tag.Name));
	}
}
