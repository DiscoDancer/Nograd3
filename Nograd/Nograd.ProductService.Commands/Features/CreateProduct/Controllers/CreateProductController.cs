using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nograd.ProductService.Commands.Features.CreateProduct.Mappers;

namespace Nograd.ProductService.Commands.Features.CreateProduct.Controllers;

[ApiController]
[Route(CreateProductControllerRoutes.ControllerRoute)]
public sealed class CreateProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICreateProductControllerInputToCommandMapper _mapper;
    private readonly ILogger<CreateProductController> _logger;


    public CreateProductController(
        IMediator mediator,
        ICreateProductControllerInputToCommandMapper mapper,
        ILogger<CreateProductController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpPost]
    [Route(CreateProductControllerRoutes.ActionRoute)]
    public async Task<ActionResult> CreateProductAsync(CreateProductControllerInput input)
    {
        var productId = Guid.NewGuid();

        try
        {
            var command = _mapper.Map(input, productId);
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created,
                new CreateProductControllerOutput(productId, "New product creation request completed successfully!"));
        }
        catch (Exception e)
        {
            const string safeErrorMessage = "Error while processing request to create a new product!";
            _logger.Log(LogLevel.Error, e, safeErrorMessage);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new CreateProductControllerOutput(productId, safeErrorMessage));
        }
    }
}