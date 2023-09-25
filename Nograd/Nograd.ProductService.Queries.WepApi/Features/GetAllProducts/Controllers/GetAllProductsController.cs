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
    public async Task<ActionResult> GetAllProductsAsync(int take = 100, int skip = 0, string? category = null)
    {
        try
        {
            var commandResult = await _mediator.Send(new GetAllProductsQuery(take, skip, category));
            var outputResult = _mapper.Map(commandResult);

            if (!outputResult.Products.Any())
                return NoContent();

            return Ok(outputResult);
        }
        catch (Exception e)
        {
            const string safeErrorMessage = "Error while processing request to retrieve all products!";
            return ErrorResponse(e, safeErrorMessage);
        }
    }

    private ActionResult ErrorResponse(Exception ex, string safeErrorMessage)
    {
        _logger.LogError(ex, safeErrorMessage);

        return StatusCode(StatusCodes.Status500InternalServerError, new GetAllProductsErrorResponse(safeErrorMessage));
    }
}