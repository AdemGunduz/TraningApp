using AppBack.Core.Application.Dto.Categories;
using AppBack.Core.Domain;
using AutoMapper;

namespace AppBack.Core.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}
