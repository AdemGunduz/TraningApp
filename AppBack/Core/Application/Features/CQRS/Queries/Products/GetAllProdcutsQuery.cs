using AppBack.Core.Application.Dto.Products;
using AppBack.Core.Application.Interfaces;
using AppBack.Core.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;

namespace AppBack.Core.Application.Features.CQRS.Queries.Products
{
    public class GetAllProdcutsQuery : IRequest<List<ProductListDto>>
    {
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProdcutsQuery, List<ProductListDto>>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProdcutsQuery request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return this.mapper.Map<List<ProductListDto>>(data);
        }
    }
}
