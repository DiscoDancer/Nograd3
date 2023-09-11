using Nograd.ProductService.Queries.Persistence.Entities;

namespace Nograd.ProductService.Queries.Persistence.Repositories;

public interface IWriteProductRepository
{
    Task CreateAsync(ProductEntity product);
    Task UpdateAsync(ProductEntity product);
    Task RemoveAsync(Guid productId);
}