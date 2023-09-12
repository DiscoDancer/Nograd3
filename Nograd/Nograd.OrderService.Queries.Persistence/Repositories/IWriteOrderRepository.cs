﻿using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.Persistence.Repositories;

public interface IWriteOrderRepository
{
    Task CreateAsync(OrderEntity order);
    Task UpdateAsync(OrderEntity order);
    Task RemoveAsync(Guid orderId);
}