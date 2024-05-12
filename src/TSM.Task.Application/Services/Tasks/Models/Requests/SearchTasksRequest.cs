using System;
using System.Collections.Generic;

namespace TSM.Task.Application.Services.Tasks.Models.Requests;

public sealed record SearchTasksRequest
{
	public IReadOnlyList<byte?> Categories { get; init; }

	public IReadOnlyList<byte?> Priorities { get; init; }

	public IReadOnlyList<Guid?> Tags { get; init; }

	public DateTime? DeadlineBy { get; init; }

	public int? Page { get; init; }

	public int? Size { get; init; }
}
