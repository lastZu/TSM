using System;

namespace TSM.Task.Domain.Entities;

public sealed class Tag
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
}
