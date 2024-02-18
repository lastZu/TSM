using System;
using System.Collections.Generic;

namespace TSM.Task.Application.Services.Tasks.Models.Requests;

public class SearchTaskRequest
{
    public List<string> Categories { get; set; }

    public List<string> Priorities { get; set; }

    public List<string> Tags { get; set; }

    public DateTime? DeadlineBy { get; set; }

    public int Page { get; set; }

    public int Size { get; set; }
}
