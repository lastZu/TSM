namespace TSM.Task.Application.Services.Tasks.Models.Responses;

public class PagedList<T>
{
    public T[] Items { get; set; }

    public int Page { get; set; }

    public int Size { get; set; }

    public int TotalCount { get; set; }
}
