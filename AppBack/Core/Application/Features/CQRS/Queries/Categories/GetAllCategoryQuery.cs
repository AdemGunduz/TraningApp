using AppBack.Core.Application.Dto.Categories;
using AppBack.Core.Application.Interfaces;
using AppBack.Core.Domain;
using AutoMapper;
using MediatR;

namespace AppBack.Core.Application.Features.CQRS.Queries.Categories
{
    public class GetAllCategoryQuery : IRequest <List<CategoryListDto>>
    {
    }

    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryListDto>>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public GetAllCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<CategoryListDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
           var data = await repository.GetAllAsync();
           return mapper.Map<List<CategoryListDto>>(data);
        }
    }
}
