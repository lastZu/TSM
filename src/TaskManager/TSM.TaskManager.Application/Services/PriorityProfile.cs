using AutoMapper;
using TSM.TaskManager.Application.Services.Priorities;
using TSM.TaskManager.Domain.Entities;

namespace TSM.TaskManager.Application.Services;

internal sealed class PriorityProfile : Profile
{
	public PriorityProfile()
	{
		MapPriorityDto();
	}

	private void MapPriorityDto()
	{
		CreateMap<Priority, PriorityDto>();
	}
}
