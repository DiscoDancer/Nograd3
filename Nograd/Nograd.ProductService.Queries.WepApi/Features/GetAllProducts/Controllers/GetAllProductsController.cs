using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Mappers;
using Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Queries;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class GetAllProductsController : ControllerBase
{
    private readonly ILogger<GetAllProductsController> _logger;
    private readonly IMediator _mediator;
    private readonly IGetAllProductsMapper _mapper;

    public GetAllProductsController(
        ILogger<GetAllProductsController> logger, IMediator mediator, IGetAllProductsMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult> GetAllProductsAsync()
    {
        try
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            var exportProducts = products.Select(_mapper.Map).ToList();

            return NormalResponse(exportProducts);
        }
        catch (Exception e)
        {
            const string safeErrorMessage = "Error while processing request to retrieve all products!";
            return ErrorResponse(e, safeErrorMessage);
        }
    }

    private ActionResult NormalResponse(List<GetAllProductsExportProduct> products)
    {
        if (!products.Any())
            return NoContent();

        var count = products.Count;
        return Ok(new GetAllProductsSuccessResponse(products,
            $"Successfully returned {count} product{(count > 1 ? "s" : string.Empty)}!"));
    }

    private ActionResult ErrorResponse(Exception ex, string safeErrorMessage)
    {
        _logger.LogError(ex, safeErrorMessage);

        return StatusCode(StatusCodes.Status500InternalServerError, new GetAllProductsErrorResponse(safeErrorMessage));
    }
}