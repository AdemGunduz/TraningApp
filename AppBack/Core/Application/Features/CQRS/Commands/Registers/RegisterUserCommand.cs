using AppBack.Core.Application.Enums;
using AppBack.Core.Application.Interfaces;
using AppBack.Core.Domain;
using AutoMapper;
using MediatR;

namespace AppBack.Core.Application.Features.CQRS.Commands.Registers
{
    public class RegisterUserCommand : IRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IRepository<AppUser> repository;
        private readonly IMapper mapper;

        public RegisterUserCommandHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new AppUser
            {
                Password = request.Password,
                UserName = request.Username,
                AppRoleId = (int)RoleType.Member,
            });
            return Unit.Value;
        }
    }
}
