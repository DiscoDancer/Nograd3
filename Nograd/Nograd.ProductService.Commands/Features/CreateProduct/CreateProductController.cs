using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nograd.ProductService.Commands.Features.Base;

namespace Nograd.ProductService.Commands.Features.CreateProduct
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class CreateProductController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IControllerInputToCommandMapper<CreateProductControllerInput, CreateProductCommand> _mapper;


        public CreateProductController(
            IMediator mediator,
            IControllerInputToCommandMapper<CreateProductControllerInput, CreateProductCommand> mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductAsync(CreateProductControllerInput input)
        {
            var command = _mapper.Map(input);
            await _mediator.Send(command);

            throw new NotImplementedException();
        }
    }
}
