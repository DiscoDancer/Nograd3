using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nograd.ProductService.Queries.WepApi.Features.GetAllCategories.Queries;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllCategories.Controllers;

[ApiController]
[Route(GetAllCategoriesRoutes.ControllerRoute)]
public class GetAllCategoriesController : ControllerBase
{
    private readonly ILogger<GetAllCategoriesController> _logger;
    private readonly IMediator _mediator;

    public GetAllCategoriesController(ILogger<GetAllCategoriesController> logger, IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    [Route(GetAllCategoriesRoutes.ActionRoute)]
    public async Task<ActionResult> GetAllCategoriesAsync()
    {
        try
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());

            if (!categories.Any())
                return NoContent();

            return Ok(categories);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get all categories.");
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get all categories.");
        }
    }
}