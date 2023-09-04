using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Nograd.ProductService.Commands.Features.CreateProduct
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class CreateProductController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICreateProductControllerInputToCommandMapper _mapper;


        public CreateProductController(
            IMediator mediator,
            ICreateProductControllerInputToCommandMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductAsync(CreateProductControllerInput input)
        {
            var command = _mapper.Map(input, Guid.NewGuid());
            await _mediator.Send(command);

            throw new NotImplementedException();
        }
    }
}
