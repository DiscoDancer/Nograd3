namespace Nograd.ProductService.Commands.Domain.Events;

public sealed record ProductUpdatedEvent(
    string Name,
    string Description,
    string Category,
    decimal Price,
    Guid ProductId
) : BaseEvent;