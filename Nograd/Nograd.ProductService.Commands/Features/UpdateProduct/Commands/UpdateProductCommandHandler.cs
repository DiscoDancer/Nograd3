using MediatR;
using Nograd.ProductService.Commands.Domain;

namespace Nograd.ProductService.Commands.Features.UpdateProduct.Commands;

public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IEventStore _eventStore;
    private readonly IProductEventHandlingStrategy _eventHandlingStrategy;

    public UpdateProductCommandHandler(IEventStore store, IProductEventHandlingStrategy eventHandlingStrategy)
    {
        _eventStore = store ?? throw new ArgumentNullException(nameof(store));
        _eventHandlingStrategy =
            eventHandlingStrategy ?? throw new ArgumentNullException(nameof(eventHandlingStrategy));
    }

    public async Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var events = await _eventStore.GetEventsAsync(command.ProductId);
        var product = EventApplicator.RestoreFromEvents(events);
        var productUpdatedEvent = ProductEventProducer.Update(
            product,
            command.Name,
            command.Description,
            command.Category,
            command.Price);

        await _eventHandlingStrategy.HandleAsync(productUpdatedEvent, productUpdatedEvent.ProductId);
    }
}