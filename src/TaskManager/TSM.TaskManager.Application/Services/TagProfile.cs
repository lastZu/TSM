using AutoMapper;
using TSM.TaskManager.Application.Services.Tags.Models.Requests;
using TSM.TaskManager.Application.Services.Tags.Models.Responses;
using TSM.TaskManager.Domain.Entities;

namespace TSM.TaskManager.Application.Services;

internal sealed class TagProfile : Profile
{
	public TagProfile()
	{
		MapTag();
		MapCreate();
		MapUpdate();
		MapTagDto();
	}

	private void MapTag()
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

	private void MapTagDto()
	{
		CreateMap<Tag, TagDto>();
	}
}
