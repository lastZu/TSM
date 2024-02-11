using System;

namespace TSM.Task.Application.Services.Tags.Models.Requests;

public class CreateTagRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}