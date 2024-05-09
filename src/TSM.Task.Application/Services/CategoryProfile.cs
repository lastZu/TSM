using AutoMapper;
using TSM.Task.Application.Services.Categories;
using TSM.Task.Domain.Entities;

namespace TSM.Task.Application.Services;

internal sealed class CategoryProfile : Profile
{
	public CategoryProfile()
	{
		MapCategoryDto();
	}

	private void MapCategoryDto()
	{
		CreateMap<Category, CategoryDto>();
	}
}
