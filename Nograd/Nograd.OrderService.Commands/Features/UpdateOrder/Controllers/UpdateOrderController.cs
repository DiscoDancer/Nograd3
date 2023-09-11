using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nograd.OrderService.Commands.Features.UpdateOrder.Mappers;

namespace Nograd.OrderService.Commands.Features.UpdateOrder.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class UpdateOrderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUpdateOrderControllerInputToCommandMapper _mapper;
    private readonly ILogger<UpdateOrderController> _logger;

    public UpdateOrderController(
        IMediator mediator,
        ILogger<UpdateOrderController> logger,
        IUpdateOrderControllerInputToCommandMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateOrderAsync(UpdateOrderControllerInput input)
    {
        try
        {
            var command = _mapper.Map(input);
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status202Accepted,
                new UpdateOrderControllerOutput(command.OrderId, "Update order request completed successfully!"));
        }
        catch (Exception e)
        {
            const string safeErrorMessage = "Error while processing request to update the new order!";
            _logger.Log(LogLevel.Error, e, safeErrorMessage);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new UpdateOrderControllerOutput(input.Id, safeErrorMessage));
        }
    }
}