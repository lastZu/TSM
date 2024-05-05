using System;

namespace TSM.Task.Application.Services.Tags.Models.Responses;

public class UpdateTagResponse
{
	public Guid Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }
}
