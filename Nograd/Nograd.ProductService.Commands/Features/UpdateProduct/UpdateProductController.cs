using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Nograd.ProductService.Commands.Features.UpdateProduct;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class UpdateProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUpdateProductControllerInputToCommandMapper _mapper;


    public UpdateProductController(
        IMediator mediator,
        IUpdateProductControllerInputToCommandMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProductAsync(UpdateProductControllerInput input)
    {
        var command = _mapper.Map(input);
        await _mediator.Send(command);

        throw new NotImplementedException();
    }
}