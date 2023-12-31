﻿using Nograd.ProductService.Commands.Domain.Events;

namespace Nograd.ProductService.Commands.Domain
{
    public interface IEventStore
    {
        Task SaveEventAsync(BaseEvent @event, Guid productId);
        Task<List<BaseEvent>> GetEventsAsync(Guid productId);
    }
}
