using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Mappers;
using Nograd.ProductService.Queries.WepApi.Features.GetProductById.Queries;

namespace Nograd.ProductService.Queries.WepApi.Features.GetProductById.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class GetProductByIdController : ControllerBase
{
    private readonly ILogger<GetProductByIdController> _logger;
    private readonly IMediator _mediator;
    private readonly IGetAllProductsMapper _mapper;

    public GetProductByIdController(
        ILogger<GetProductByIdController> logger,
        IMediator mediator,
        IGetAllProductsMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult> GetProductByIdAsync(Guid productId)
    {
        if (productId == Guid.Empty) throw new ArgumentNullException(nameof(productId));

        try
        {
            var product = await _mediator.Send(new GetProductByIdQuery(productId));
            if (product == null)
            {
                return NotFound();
            }

            var exportProduct = _mapper.Map(product);
            return Ok(exportProduct);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to get product by id {productId}");
            return BadRequest();
        }
    }
}