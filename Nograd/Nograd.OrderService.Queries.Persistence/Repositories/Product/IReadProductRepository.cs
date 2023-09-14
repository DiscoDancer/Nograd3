using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.Persistence.Repositories.Product;

public interface IReadProductRepository
{
    Task<ProductEntity?> GetByIdAsync(Guid productId);
    Task<List<ProductEntity>> ListAllAsync();
}