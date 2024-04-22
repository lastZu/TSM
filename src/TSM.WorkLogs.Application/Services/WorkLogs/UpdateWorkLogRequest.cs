using System;

namespace TSM.WorkLogs.Application.Services.WorkLogs;

public class UpdateWorkLogRequest
{
    public Guid TaskId { get; set; }

    public int Time { get; set; }

    public string Comment { get; set; }

    public DateTime Date { get; set; }
}
