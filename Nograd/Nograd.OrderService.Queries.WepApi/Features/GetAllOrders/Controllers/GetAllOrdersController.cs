using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Mappers;
using Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Queries;

namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;

[ApiController]
[Route(GetAllOrdersControllerRoutes.ControllerRoute)]
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
    [Route(GetAllOrdersControllerRoutes.ActionRoute)]
    public async Task<ActionResult> GetAllOrdersAsync()
    {
        try
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            var exportOrders = orders.Select(_mapper.Map).ToList();

            return Ok(new GetAllOrdersControllerOutput
            {
                Orders = exportOrders,
                Message =
                    $"Successfully returned {exportOrders.Count} Order{(exportOrders.Count > 1 ? "s" : string.Empty)}!",
            });
        }
        catch (Exception e)
        {
            const string safeErrorMessage = "Error while processing request to retrieve all orders!";
            _logger.LogError(e, safeErrorMessage);
            var result = new GetAllOrdersControllerOutput
            {
                Orders = null,
                Message = safeErrorMessage,
            };

            return StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}