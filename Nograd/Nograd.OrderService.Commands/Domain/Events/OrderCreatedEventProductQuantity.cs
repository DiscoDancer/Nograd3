namespace Nograd.OrderService.Commands.Domain.Events;

public sealed record OrderCreatedEventProductQuantity(Guid ProductId, int Quantity);
