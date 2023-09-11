using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nograd.ProductService.Commands.Features.UpdateProduct.Mappers;

namespace Nograd.ProductService.Commands.Features.UpdateProduct.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class UpdateProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUpdateProductControllerInputToCommandMapper _mapper;
    private readonly ILogger<UpdateProductController> _logger;


    public UpdateProductController(
        IMediator mediator,
        IUpdateProductControllerInputToCommandMapper mapper,
        ILogger<UpdateProductController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProductAsync(UpdateProductControllerInput input)
    {
        try
        {
            var command = _mapper.Map(input);
            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status202Accepted, new UpdateProductControllerOutput(command.ProductId, "Updating product request completed successfully!"));
        }
        catch (Exception e)
        {
            const string safeErrorMessage = "Error while processing request to update the product!";
            _logger.Log(LogLevel.Error, e, safeErrorMessage);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new UpdateProductControllerOutput(input.ProductId, safeErrorMessage));
        }
    }
}