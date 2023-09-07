using MediatR;
using Nograd.OrderService.Commands.Domain;

namespace Nograd.OrderService.Commands.Features.CreateOrder
{
    public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderEventHandlingStrategy _eventHandlingStrategy;

        public CreateOrderCommandHandler(IOrderEventHandlingStrategy eventHandlingStrategy)
        {
            _eventHandlingStrategy = eventHandlingStrategy ?? throw new ArgumentNullException(nameof(eventHandlingStrategy));
        }

        public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
