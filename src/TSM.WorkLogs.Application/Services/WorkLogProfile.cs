using AutoMapper;
using TSM.WorkLogs.Application.Services.WorkLogs;
using TSM.WorkLogs.Domain.Entities;

namespace TSM.WorkLogs.Application.Services;

public class WorkLogProfile : Profile
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
        CreateMap<WorkLog, WorkLogResponse>();
    }

    private void MapByID()
    {
        CreateMap<WorkLog, WorkLogByIdResponse>();
    }

    private void MapCreate()
    {
        CreateMap<CreateWorkLogRequest, WorkLog>();
    }

    private void MapUpdate()
    {
        CreateMap<UpdateWorkLogRequest, WorkLog>();
    }
}
