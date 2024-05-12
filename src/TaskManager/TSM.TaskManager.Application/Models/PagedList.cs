using System.Collections.Generic;

namespace TSM.TaskManager.Application.Models;

public sealed record PagedList<T>
{
	public IReadOnlyList<T> Items { get; init; }

	public int Page { get; init; }

	public int Size { get; init; }

	public int TotalCount { get; init; }
}
