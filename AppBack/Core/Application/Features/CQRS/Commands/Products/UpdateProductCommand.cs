using AppBack.Core.Application.Interfaces;
using AppBack.Core.Domain;
using AutoMapper;
using MediatR;

namespace AppBack.Core.Application.Features.CQRS.Commands.Products
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updateEntity = await this.repository.GetByIdAsync(request.Id);
            if (updateEntity != null)
            {
                updateEntity.Name = request.Name;
                updateEntity.Stock = request.Stock;
                updateEntity.Price = request.Price;
                updateEntity.CategoryId = request.CategoryId;
                await this.repository.UpdateAsync(updateEntity);
            }
            return Unit.Value;
        }
    }
}
