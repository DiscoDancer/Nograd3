using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nograd.OrderService.Commands.Features.CreateOrder.Mappers;

namespace Nograd.OrderService.Commands.Features.CreateOrder.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class CreateOrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICreateOrderControllerInputToCommandMapper _mapper;
        private readonly ILogger<CreateOrderController> _logger;

        public CreateOrderController(
            IMediator mediator,
            ILogger<CreateOrderController> logger,
            ICreateOrderControllerInputToCommandMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrderAsync(CreateOrderControllerInput input)
        {
            var orderId = Guid.NewGuid();

            try
            {
                var command = _mapper.Map(input, orderId);
                await _mediator.Send(command);
                return StatusCode(StatusCodes.Status201Created,
                    new CreateOrderControllerOutput(orderId, "New order creation request completed successfully!"));
            }
            catch (Exception e)
            {
                const string safeErrorMessage = "Error while processing request to create a new order!";
                _logger.Log(LogLevel.Error, e, safeErrorMessage);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new CreateOrderControllerOutput(orderId, safeErrorMessage));
            }
        }
    }
}
