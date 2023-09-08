using Nograd.OrderService.Commands.Domain.Events;

namespace Nograd.OrderService.Commands.Domain
{
    public sealed record Order(Guid Id, OrderLifecycleStates State)
    {
        public static Order GetNotCreatedOrder()
        {
            return new Order(Guid.Empty, OrderLifecycleStates.ToBeCreated);
        }
        public Order Apply(OrderCreatedEvent @event)
        {
            return new Order(Id: @event.OrderId, State: OrderLifecycleStates.Created);
        }

        public Order Apply(OrderUpdatedEvent @event)
        {
            return this;
        }

        public Order Apply(OrderRemovedEvent @event)
        {
            return this with { State = OrderLifecycleStates.Deleted };
        }
    }
}
