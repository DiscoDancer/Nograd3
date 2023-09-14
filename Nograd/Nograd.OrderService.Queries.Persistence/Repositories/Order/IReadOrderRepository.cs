using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.Persistence.Repositories.Order;

public interface IReadOrderRepository
{
    Task<OrderEntity?> GetByIdAsync(Guid orderId);
    Task<List<OrderEntity>> ListAllAsync();
}