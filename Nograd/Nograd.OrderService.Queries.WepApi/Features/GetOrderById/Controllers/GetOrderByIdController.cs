using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nograd.OrderService.Queries.WepApi.Features.GetOrderById.Mappers;
using Nograd.OrderService.Queries.WepApi.Features.GetOrderById.Queries;

namespace Nograd.OrderService.Queries.WepApi.Features.GetOrderById.Controllers;

[ApiController]
[Route(GetOrderByIdControllerRoutes.ControllerRoute)]
public sealed class GetOrderByIdController : ControllerBase
{
    private readonly ILogger<GetOrderByIdController> _logger;
    private readonly IMediator _mediator;
    private readonly IGetOrderByIdMapper _mapper;

    public GetOrderByIdController(
        ILogger<GetOrderByIdController> logger,
        IMediator mediator,
        IGetOrderByIdMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    [Route(GetOrderByIdControllerRoutes.ActionRoute)]
    public async Task<ActionResult> GetOrderByIdAsync(Guid orderId)
    {
        if (orderId == Guid.Empty) throw new ArgumentNullException(nameof(orderId));

        try
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(orderId));
            if (order == null) return Ok(null);

            var exportOrder = _mapper.Map(order);
            return Ok(exportOrder);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to get order by id {orderId}");
            return BadRequest();
        }
    }
}