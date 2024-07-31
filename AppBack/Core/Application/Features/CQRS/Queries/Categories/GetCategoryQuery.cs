using AppBack.Core.Application.Dto.Categories;
using AppBack.Core.Application.Interfaces;
using AppBack.Core.Domain;
using AutoMapper;
using MediatR;

namespace AppBack.Core.Application.Features.CQRS.Queries.Categories
{
    public class GetCategoryQuery : IRequest<CategoryListDto?>
    {
        public GetCategoryQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryListDto?>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<CategoryListDto?> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
           var result =  await repository.GetByFilterAsync( x=>x.Id == request.Id );
            return mapper.Map<CategoryListDto>( result );

        }
    }
}
