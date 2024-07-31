using AppBack.Core.Application.Interfaces;
using AppBack.Core.Domain;
using AutoMapper;
using MediatR;

namespace AppBack.Core.Application.Features.CQRS.Commands.Products
{
    public class DeleteProductCommand : IRequest
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public DeleteProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           var deletedEntity = await this.repository.GetByIdAsync(request.Id);
            if (deletedEntity !=null)
            {
                await this.repository.RemoveAsync(deletedEntity);
            }
            return Unit.Value;
            
        }
    }
}
