using System;
using System.Collections.Generic;

namespace TSM.Task.Domain.Entities;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Task> Tasks { get; set; }
}