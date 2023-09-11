using MediatR;
using Nograd.ProductService.Commands.Domain;

namespace Nograd.ProductService.Commands.Features.RemoveProduct.Commands;

public sealed class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
{
    private readonly IEventStore _eventStore;
    private readonly IProductEventHandlingStrategy _eventHandlingStrategy;

    public RemoveProductCommandHandler(IEventStore store, IProductEventHandlingStrategy eventHandlingStrategy)
    {
        _eventStore = store ?? throw new ArgumentNullException(nameof(store));
        _eventHandlingStrategy =
            eventHandlingStrategy ?? throw new ArgumentNullException(nameof(eventHandlingStrategy));
    }

    public async Task Handle(RemoveProductCommand command, CancellationToken cancellationToken)
    {
        var events = await _eventStore.GetEventsAsync(command.ProductId);
        var product = EventApplicator.RestoreFromEvents(events);
        var productRemovedEvent = ProductEventProducer.Remove(product);

        await _eventHandlingStrategy.HandleAsync(productRemovedEvent, productRemovedEvent.ProductId);
    }
}