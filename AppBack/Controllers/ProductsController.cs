using AppBack.Core.Application.Features.CQRS.Commands.Products;
using AppBack.Core.Application.Features.CQRS.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AppBack.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await this._mediator.Send(new GetAllProdcutsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            var result = await this._mediator.Send(new GetProductQuery(id));
            return result == null ? NotFound() : Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand request)
        {
            await this._mediator.Send(request);
            return Created("", request);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this._mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand request)
        {
            await this._mediator.Send(request);
            return NoContent();
        }

    }
    
}
