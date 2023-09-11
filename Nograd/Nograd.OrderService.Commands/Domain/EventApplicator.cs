using Nograd.OrderService.Commands.Domain.Events;

namespace Nograd.OrderService.Commands.Domain;

public static class EventApplicator
{
    public static Order ApplyEvent(Order order, BaseEvent @event)
    {
        var method = typeof(Order).GetMethod("Apply", new[] { @event.GetType() });
        if (method == null)
            throw new ArgumentNullException(nameof(method),
                $"The Apply method was not found for {@event.GetType().Name}!");

        var result = (Order?)method.Invoke(order, new object[] { @event }) ??
                     throw new Exception("Event application failed");

        return result;
    }

    public static Order RestoreFromEvents(IEnumerable<BaseEvent> events)
    {
        var product = Order.GetNotCreatedOrder();
        return events.Aggregate(product, ApplyEvent);
    }
}