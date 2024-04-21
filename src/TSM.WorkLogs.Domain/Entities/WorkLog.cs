using System;

namespace TSM.WorkLogs.Domain.Entities;

public class WorkLog
{
    public Guid Id { get; set; }

    public Guid? TaskId { get; set; }

    public int? Time { get; set; }

    public string Comment { get; set; }

    public DateTime? Date { get; set; }
}
