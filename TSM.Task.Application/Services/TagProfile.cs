using AutoMapper;
using TSM.Task.Application.Services.Tags.Models.Requests;
using TSM.Task.Application.Services.Tags.Models.Responses;
using TSM.Task.Domain.Entities;


namespace TSM.Task.Application.Services;

public class TagProfile : Profile
{
    public TagProfile()
    {
        MapTask();
        MapCreate();
        MapUpdate();
    }

    private void MapTask()
    {
        CreateMap<Tag, TagResponse>();
    }

    private void MapCreate()
    {
        CreateMap<CreateTagRequest, Tag>();
        CreateMap<Tag, CreateTagResponse>();
    }

    private void MapUpdate()
    {
        CreateMap<UpdateTagRequest, Tag>();
        CreateMap<Tag, UpdateTagResponse>();
    }
}