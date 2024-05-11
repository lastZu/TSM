namespace TSM.Task.Application.Services.Categories;

public sealed record CategoryDto
{
	public byte Id { get; init; }

	public string Name { get; init; }
}
