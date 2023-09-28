using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nograd.OrderService.Commands.Features.RemoveOrder.Mappers;

namespace Nograd.OrderService.Commands.Features.RemoveOrder.Controllers;

[ApiController]
[Route(RemoveOrderControllerRoutes.ControllerRoute)]
public sealed class RemoveOrderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRemoveOrderControllerInputToCommandMapper _mapper;
    private readonly ILogger<RemoveOrderController> _logger;

    public RemoveOrderController(
        IMediator mediator,
        IRemoveOrderControllerInputToCommandMapper mapper,
        ILogger<RemoveOrderController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpDelete]
    [Route(RemoveOrderControllerRoutes.ActionRoute)]
    public async Task<ActionResult> RemoveOrderAsync(RemoveOrderControllerInput input)
    {
        try
        {
            var command = _mapper.Map(input);
            await _mediator.Send(command);


            return StatusCode(StatusCodes.Status202Accepted,
                new RemoveOrderControllerOutput(command.OrderId,
                    "Removing order request completed successfully!"));
        }
        catch (Exception e)
        {
            const string safeErrorMessage = "Error while processing request to remove the order!";
            _logger.Log(LogLevel.Error, e, safeErrorMessage);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new RemoveOrderControllerOutput(input.OrderId, safeErrorMessage));
        }
    }
}