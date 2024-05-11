namespace TSM.Task.Application.Services.Priorities;

public sealed record PriorityDto
{
	public byte Id { get; init; }

	public string Name { get; init; }
}
