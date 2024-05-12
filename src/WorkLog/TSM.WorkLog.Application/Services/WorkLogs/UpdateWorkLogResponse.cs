using System;

namespace TSM.WorkLog.Application.Services.WorkLogs;

public sealed record UpdateWorkLogResponse
{
	public Guid Id { get; init; }
}
