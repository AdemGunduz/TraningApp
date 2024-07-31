using AppBack.Core.Application.Interfaces;
using AppBack.Core.Domain;
using AutoMapper;
using MediatR;

namespace AppBack.Core.Application.Features.CQRS.Commands.Categories
{
    public class CreateCategoryCommand : IRequest
    {
        public string? Definition { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Category
            {
                Definition = request.Definition,
            });
            return Unit.Value;
        }
    }
}
