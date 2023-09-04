using Nograd.ProductService.Commands.Domain.Events;

namespace Nograd.ProductService.Commands.Domain
{
    public sealed class SaveAndNotifyEventHandlingStrategy : IProductEventHandlingStrategy
    {
        private readonly IEventStore _eventStore;
        private readonly IEventNotificator _eventNotificator;

        public SaveAndNotifyEventHandlingStrategy(IEventStore store, IEventNotificator eventNotificator)
        {
            _eventStore = store ?? throw new ArgumentNullException(nameof(store));
            _eventNotificator = eventNotificator ?? throw new ArgumentNullException(nameof(eventNotificator));
        }

        public async Task HandleAsync(BaseEvent @event, Guid productId)
        {
            await _eventStore.SaveEventAsync(@event, productId);
            await _eventNotificator.Notify(@event);
        }
    }
}
