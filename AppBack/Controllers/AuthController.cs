using AppBack.Core.Application.Features.CQRS.Commands.Registers;
using AppBack.Core.Application.Features.CQRS.Queries;
using AppBack.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register (RegisterUserCommand request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQuery request)
        {
            var dto = await _mediator.Send(request);
            if (dto.IsExist)
            {
             
                return Created("", JwtTokenGenerator.GenerateToken(dto));

            }
            else
            {
                return BadRequest("Kullanici adi veya sifre hatali");
            }
        }
    }
}
