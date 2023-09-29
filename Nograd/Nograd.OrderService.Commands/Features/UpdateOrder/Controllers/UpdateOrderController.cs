using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nograd.OrderService.Commands.Features.UpdateOrder.Mappers;
using Nograd.ProductService.Queries.Client;

namespace Nograd.OrderService.Commands.Features.UpdateOrder.Controllers;

[ApiController]
[Route(UpdateOrderControllerRoutes.ControllerRoute)]
public sealed class UpdateOrderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUpdateOrderControllerInputToCommandMapper _mapper;
    private readonly ILogger<UpdateOrderController> _logger;
    private readonly IProductQueriesClient _productQueriesClient;

    public UpdateOrderController(
        IMediator mediator,
        ILogger<UpdateOrderController> logger,
        IUpdateOrderControllerInputToCommandMapper mapper,
        IProductQueriesClient productQueriesClient)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _productQueriesClient = productQueriesClient ?? throw new ArgumentNullException(nameof(productQueriesClient));
    }

    [HttpPut]
    [Route(UpdateOrderControllerRoutes.ActionRoute)]
    public async Task<ActionResult> UpdateOrderAsync(UpdateOrderControllerInput input)
    {
        try
        {
            var command = _mapper.Map(input);

            foreach (var productQuantity in command.ProductQuantities)
            {
                var productId = productQuantity.ProductId;
                var foundProduct = await _productQueriesClient.GetProductByIdOrDefaultAsync(productId);
                if (foundProduct == null)
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new UpdateOrderControllerOutput(input.Id,
                            $"Can't update order because product with id {productId} not found or not exists"));
            }

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