using System;

namespace TSM.WorkLogs.Application.Services.WorkLogs;

public sealed record CreateWorkLogRequest
{
	public Guid TaskId { get; init; }

	public int Time { get; init; }

	public string Comment { get; init; }

	public DateTime Date { get; init; }
}
