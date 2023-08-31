﻿namespace Nograd.ProductService.Commands.Domain.Events;

public sealed class ProductUpdatedEvent : BaseEvent
{
    public ProductUpdatedEvent() : base(nameof(ProductUpdatedEvent))
    {
    }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public decimal? Price { get; set; }
    public Guid? ProductId { get; set; }
}