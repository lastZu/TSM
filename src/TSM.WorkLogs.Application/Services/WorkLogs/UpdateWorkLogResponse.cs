using System;

namespace TSM.WorkLogs.Application.Services.WorkLogs;

public sealed record UpdateWorkLogResponse
{
	public Guid Id { get; init; }
}
