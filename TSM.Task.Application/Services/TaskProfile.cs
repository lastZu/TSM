using AutoMapper;
using TSM.Task.Application.Services.Tasks.Models.Requests;
using TSM.Task.Application.Services.Tasks.Models.Responses;

namespace TSM.Task.Application.Services;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        MapTask();
        MapById();
        MapCreate();
        MapUpdate();
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
        CreateMap<Domain.Entities.Task, CreateTaskResponse>();
    }

    private void MapUpdate()
    {
        CreateMap<UpdateTaskRequest, Domain.Entities.Task>();
        CreateMap<Domain.Entities.Task, UpdateTaskResponse>();
    }
}