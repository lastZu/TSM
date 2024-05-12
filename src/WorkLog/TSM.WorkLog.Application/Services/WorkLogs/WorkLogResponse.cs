using System;

namespace TSM.WorkLog.Application.Services.WorkLogs;

public sealed record WorkLogResponse
{
	public Guid Id { get; init; }

	public Guid TaskId { get; init; }

	public int Time { get; init; }

	public string Comment { get; init; }

	public DateTime Date { get; init; }
}
