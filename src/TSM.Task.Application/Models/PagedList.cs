using System.Collections.Generic;

namespace TSM.Task.Application.Models;

public sealed class PagedList<T>
{
	public IReadOnlyList<T> Items { get; set; }

	public int Page { get; set; }

	public int Size { get; set; }

	public int TotalCount { get; set; }
}
