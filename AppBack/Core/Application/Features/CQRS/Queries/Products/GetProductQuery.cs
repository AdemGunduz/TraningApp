using AppBack.Core.Application.Dto.Products;
using AppBack.Core.Application.Interfaces;
using AppBack.Core.Domain;
using AutoMapper;
using MediatR;

namespace AppBack.Core.Application.Features.CQRS.Queries.Products
{
    public class GetProductQuery : IRequest<ProductListDto>
    {
        public GetProductQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductListDto>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public GetProductQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ProductListDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetByFilterAsync( x => x.Id == request.Id);
            return this.mapper.Map<ProductListDto>(data);
        }
    }
}
