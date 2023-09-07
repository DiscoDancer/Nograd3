namespace Nograd.OrderService.Commands.Domain.Events;

public sealed record OrderUpdatedEventProductQuantity(Guid ProductId, int Quantity);