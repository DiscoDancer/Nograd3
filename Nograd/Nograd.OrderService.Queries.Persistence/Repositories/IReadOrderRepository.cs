using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.Persistence.Repositories;

public interface IReadOrderRepository
{
    Task<OrderEntity?> GetByIdAsync(Guid orderId);
    Task<List<OrderEntity>> ListAllAsync();
}