using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.Persistence.Repositories.Product;

public interface IWriteProductRepository
{
    Task CreateAsync(ProductEntity product);
    Task UpdateAsync(ProductEntity product);
    Task RemoveAsync(Guid productId);
}