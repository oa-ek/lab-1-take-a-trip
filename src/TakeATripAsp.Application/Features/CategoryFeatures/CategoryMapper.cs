using AutoMapper;
using TakeTripAsp.Application.Features.CategoryFeatures.CategoryDtos;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CategoryFeatures
{
    public class CategoryMapper: Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<CreateCategoryDto, Category>();

            CreateMap<Category, ReadCategoryDto>();
            CreateMap<ReadCategoryDto, Category>();
        }
    }
}
