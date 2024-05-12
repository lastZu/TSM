using AutoMapper;
using TSM.WorkLog.Application.Services.WorkLogs;
using WorkLogEntity = TSM.WorkLog.Domain.Entities.WorkLog;

namespace TSM.WorkLog.Application.Services;

internal sealed class WorkLogProfile : Profile
{
	public WorkLogProfile()
	{
		MapWorkLog();
		MapByID();
		MapCreate();
		MapUpdate();
	}

	private void MapWorkLog()
	{
		CreateMap<WorkLogEntity, WorkLogResponse>();
	}

	private void MapByID()
	{
		CreateMap<WorkLogEntity, WorkLogByIdResponse>();
	}

	private void MapCreate()
	{
		CreateMap<CreateWorkLogRequest, WorkLogEntity>();
		CreateMap<WorkLogEntity, CreateWorkLogResponse>();
	}

	private void MapUpdate()
	{
		CreateMap<UpdateWorkLogRequest, WorkLogEntity>();
		CreateMap<WorkLogEntity, UpdateWorkLogResponse>();
	}
}
