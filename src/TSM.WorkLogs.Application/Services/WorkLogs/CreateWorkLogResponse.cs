using System;

namespace TSM.WorkLogs.Application.Services.WorkLogs;

public sealed record CreateWorkLogResponse
{
	public Guid Id { get; init; }
}
