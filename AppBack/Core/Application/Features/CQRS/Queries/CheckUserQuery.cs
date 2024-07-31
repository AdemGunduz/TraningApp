using AppBack.Core.Application.Dto;
using AppBack.Core.Application.Interfaces;
using AppBack.Core.Domain;
using AutoMapper;
using MediatR;

namespace AppBack.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQuery : IRequest<CheckUserDto>
    {
        public string Username { get; set; } = null!;
        public string Password  { get; set; } = null!;

    }

    public class CheckUserQueryHandler : IRequestHandler<CheckUserQuery, CheckUserDto>
    {
        private readonly IRepository<AppUser> repository;
        private readonly IRepository<AppRole> roleRepository;

        public CheckUserQueryHandler(IRepository<AppUser> repository, IRepository<AppRole> roleRepository)
        {
            this.repository = repository;
            this.roleRepository = roleRepository;
        }

        public async Task<CheckUserDto> Handle(CheckUserQuery request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserDto();
            var user = await repository.GetByFilterAsync( x => x.UserName == request.Username && x.Password == request.Password);

            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.UserName = user.UserName;
                dto.Id = user.Id;
                dto.IsExist=true;
                var role = await roleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Role = role?.Definition;
            }
            return dto;
        }
    }
}
