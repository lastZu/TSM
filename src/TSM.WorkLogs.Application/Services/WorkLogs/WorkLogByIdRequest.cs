using System;

namespace TSM.WorkLogs.Application.Services.WorkLogs;

public sealed record WorkLogByIdRequest
{
	public Guid Id { get; init; }
}
