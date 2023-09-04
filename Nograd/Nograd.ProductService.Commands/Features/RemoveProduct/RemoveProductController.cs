using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Nograd.ProductService.Commands.Features.RemoveProduct;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class RemoveProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRemoveProductControllerInputToCommandMapper _mapper;

    public RemoveProductController(
        IMediator mediator,
        IRemoveProductControllerInputToCommandMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveProductAsync(RemoveProductControllerInput input)
    {
        var command = _mapper.Map(input);
        await _mediator.Send(command);

        throw new NotImplementedException();
    }
}