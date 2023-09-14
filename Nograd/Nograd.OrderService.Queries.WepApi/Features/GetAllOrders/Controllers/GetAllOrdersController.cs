using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Mappers;
using Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Queries;

namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class GetAllOrdersController : ControllerBase
{
    private readonly ILogger<GetAllOrdersController> _logger;
    private readonly IMediator _mediator;
    private readonly IGetAllOrdersMapper _mapper;

    public GetAllOrdersController(
        ILogger<GetAllOrdersController> logger, IMediator mediator, IGetAllOrdersMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult> GetAllOrdersAsync()
    {
        try
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            var exportOrders = orders.Select(_mapper.Map).ToList();

            return NormalResponse(exportOrders);
        }
        catch (Exception e)
        {
            const string safeErrorMessage = "Error while processing request to retrieve all orders!";
            return ErrorResponse(e, safeErrorMessage);
        }
    }

    private ActionResult NormalResponse(List<GetAllOrdersExportOrder> orders)
    {
        if (!orders.Any())
            return NoContent();

        var count = orders.Count;
        return Ok(new GetAllOrdersSuccessResponse(orders,
            $"Successfully returned {count} Order{(count > 1 ? "s" : string.Empty)}!"));
    }

    private ActionResult ErrorResponse(Exception ex, string safeErrorMessage)
    {
        _logger.LogError(ex, safeErrorMessage);

        return StatusCode(StatusCodes.Status500InternalServerError, new GetAllOrdersErrorResponse(safeErrorMessage));
    }
}