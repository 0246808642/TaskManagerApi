using AutoMapper;
using TaskManagerApi.Data.Dtos.CategoryDto;
using TaskManagerApi.Models;

namespace TaskManagerApi.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, ReadCategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
