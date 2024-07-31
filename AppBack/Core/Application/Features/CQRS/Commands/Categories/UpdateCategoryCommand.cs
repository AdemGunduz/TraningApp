using AppBack.Core.Application.Interfaces;
using AppBack.Core.Domain;
using AutoMapper;
using MediatR;

namespace AppBack.Core.Application.Features.CQRS.Commands.Categories
{
    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryEntity = await repository.GetByIdAsync(request.Id);
            if (categoryEntity != null)
            {
                categoryEntity.Definition= request.Definition;
                await repository.UpdateAsync(categoryEntity);
            }

            return Unit.Value;
        }
    }
}
