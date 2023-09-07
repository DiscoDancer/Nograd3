namespace Nograd.OrderService.Commands.Domain.Events
{
    public sealed record OrderUpdatedEvent(
        IReadOnlyCollection<OrderUpdatedEventProductQuantity> ProductQuantities,
        Guid OrderId,
        bool IsShipped,
        bool IsGift,
        string CustomerName,
        string CustomerAddress
    );
}
