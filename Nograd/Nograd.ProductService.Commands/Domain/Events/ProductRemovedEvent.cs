namespace Nograd.ProductService.Commands.Domain.Events;

public sealed record ProductRemovedEvent (Guid ProductId) : BaseEvent;