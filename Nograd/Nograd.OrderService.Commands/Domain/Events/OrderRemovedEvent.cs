namespace Nograd.OrderService.Commands.Domain.Events
{
    public sealed record OrderRemovedEvent(Guid OrderId) : BaseEvent;
}
