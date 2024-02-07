using AutoMapper;
using TSM.Task.Application.Services.Tasks.Models;

namespace TSM.Task.Application.Services;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        MapCreate();
        MapUpdate();
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