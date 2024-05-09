using System;
using System.Collections.Generic;

namespace TSM.Task.Application.Services.Tasks.Models.Requests;

public sealed class SearchTasksRequest
{
	public ICollection<byte?> Categories { get; set; }

	public ICollection<byte?> Priorities { get; set; }

	public ICollection<Guid?> Tags { get; set; }

	public DateTime? DeadlineBy { get; set; }

	public int? Page { get; set; }

	public int? Size { get; set; }
}
