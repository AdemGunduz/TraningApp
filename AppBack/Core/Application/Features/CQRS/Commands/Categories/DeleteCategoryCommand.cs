using AppBack.Core.Application.Interfaces;
using AppBack.Core.Domain;
using AutoMapper;
using MediatR;

namespace AppBack.Core.Application.Features.CQRS.Commands.Categories
{
    public class DeleteCategoryCommand : IRequest
    {
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public DeleteCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var deletedEntity = await repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {
                await repository.RemoveAsync(deletedEntity);
            }
            return Unit.Value;
        }
    }

}
