namespace Nograd.ProductService.Commands.Domain.Events;

public sealed record ProductCreatedEvent(
    string Name,
    string Description,
    string Category,
    decimal Price,
    Guid ProductId
) : BaseEvent;