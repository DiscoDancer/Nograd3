using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Nograd.ProductService.Commands.Features.RemoveProduct;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class RemoveProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRemoveProductControllerInputToCommandMapper _mapper;
    private readonly ILogger<RemoveProductController> _logger;

    public RemoveProductController(
        IMediator mediator,
        IRemoveProductControllerInputToCommandMapper mapper,
        ILogger<RemoveProductController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveProductAsync(RemoveProductControllerInput input)
    {
        try
        {
            var command = _mapper.Map(input);
            await _mediator.Send(command);


            return StatusCode(StatusCodes.Status202Accepted,
                new RemoveProductControllerOutput(command.ProductId,
                    "Removing product request completed successfully!"));
        }
        catch (Exception e)
        {
            const string safeErrorMessage = "Error while processing request to remove the product!";
            _logger.Log(LogLevel.Error, e, safeErrorMessage);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new RemoveProductControllerOutput(input.ProductId, safeErrorMessage));
        }
    }
}