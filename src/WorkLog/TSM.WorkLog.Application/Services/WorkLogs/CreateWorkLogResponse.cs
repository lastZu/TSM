using System;

namespace TSM.WorkLog.Application.Services.WorkLogs;

public sealed record CreateWorkLogResponse
{
	public Guid Id { get; init; }
}
