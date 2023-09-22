using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nograd.ProductService.Queries.WepApi.Features.EnsureProductsExist.Queries;

namespace Nograd.ProductService.Queries.WepApi.Features.EnsureProductsExist.Controllers;

[ApiController]
[Route(EnsureProductsExistRoutes.ControllerRoute)]
public sealed class EnsureProductsExistController : ControllerBase
{
    private readonly ILogger<EnsureProductsExistController> _logger;
    private readonly IMediator _mediator;

    public EnsureProductsExistController(
        ILogger<EnsureProductsExistController> logger,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    [Route(EnsureProductsExistRoutes.ActionRoute)]
    public async Task<ActionResult> EnsureProductsExistAsync(IReadOnlyCollection<Guid> productIds)
    {
        if (productIds == null || !productIds.Any())
        {
            throw new ArgumentNullException(nameof(productIds));
        }

        try
        {
            var result = await _mediator.Send(new EnsureProductsExistQuery(productIds));
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to ensure that {productIds.Count} products exists");
            return BadRequest();
        }
    }
}