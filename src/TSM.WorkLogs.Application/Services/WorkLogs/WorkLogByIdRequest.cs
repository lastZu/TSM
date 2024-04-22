using System;

namespace TSM.WorkLogs.Application.Services.WorkLogs;

public sealed class WorkLogByIdRequest
{
    public Guid Id { get; set; }
}
