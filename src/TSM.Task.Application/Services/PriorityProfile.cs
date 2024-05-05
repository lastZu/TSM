using AutoMapper;
using TSM.Task.Application.Services.Priorities;
using TSM.Task.Domain.Entities;

namespace TSM.Task.Application.Services;

public class PriorityProfile : Profile
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
