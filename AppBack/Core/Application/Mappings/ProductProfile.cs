using AppBack.Core.Application.Dto.Products;
using AppBack.Core.Domain;
using AutoMapper;

namespace AppBack.Core.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
           this.CreateMap<Product,ProductListDto>().ReverseMap();
        }
    }
}
