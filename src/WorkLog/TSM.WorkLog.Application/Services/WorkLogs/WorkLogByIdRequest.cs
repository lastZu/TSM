using System;

namespace TSM.WorkLog.Application.Services.WorkLogs;

public sealed record WorkLogByIdRequest
{
	public Guid Id { get; init; }
}
