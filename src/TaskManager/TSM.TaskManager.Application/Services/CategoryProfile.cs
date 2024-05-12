using AutoMapper;
using TSM.TaskManager.Application.Services.Categories;
using TSM.TaskManager.Domain.Entities;

namespace TSM.TaskManager.Application.Services;

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
