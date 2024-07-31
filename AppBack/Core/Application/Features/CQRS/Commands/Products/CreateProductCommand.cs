using AppBack.Core.Application.Interfaces;
using AppBack.Core.Domain;
using AutoMapper;
using MediatR;

namespace AppBack.Core.Application.Features.CQRS.Commands.Products
{
    public class CreateProductCommand : IRequest
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await this.repository.CreateAsync(new Product 
            { 
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price,
                CategoryId = request.CategoryId
            });

            return Unit.Value;
        }
    }

}
