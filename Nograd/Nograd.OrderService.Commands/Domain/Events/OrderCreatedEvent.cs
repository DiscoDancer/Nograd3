namespace Nograd.OrderService.Commands.Domain.Events
{
    public sealed record OrderCreatedEvent(
        IReadOnlyCollection<OrderCreatedEventProductQuantity> ProductQuantities,
        Guid OrderId,
        bool IsShipped,
        bool IsGift, 
        string CustomerName,
        string CustomerAddress
    );
}
