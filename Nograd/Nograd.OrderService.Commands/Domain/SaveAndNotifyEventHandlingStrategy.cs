using Nograd.OrderService.Commands.Domain.Events;

namespace Nograd.OrderService.Commands.Domain
{
    public sealed class SaveAndNotifyEventHandlingStrategy : IOrderEventHandlingStrategy
    {
        private readonly IEventStore _eventStore;
        private readonly IEventNotificator _eventNotificator;

        public SaveAndNotifyEventHandlingStrategy(IEventStore store, IEventNotificator eventNotificator)
        {
            _eventStore = store ?? throw new ArgumentNullException(nameof(store));
            _eventNotificator = eventNotificator ?? throw new ArgumentNullException(nameof(eventNotificator));
        }

        public async Task HandleAsync(BaseEvent @event, Guid orderId)
        {
            await _eventStore.SaveEventAsync(@event, orderId);
            await _eventNotificator.Notify(@event);
        }
    }
}
