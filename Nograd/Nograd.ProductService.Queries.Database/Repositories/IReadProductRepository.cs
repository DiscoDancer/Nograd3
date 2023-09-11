using Nograd.ProductService.Queries.Persistence.Entities;

namespace Nograd.ProductService.Queries.Persistence.Repositories;

public interface IReadProductRepository
{
    Task<ProductEntity?> GetByIdAsync(Guid productId);
    Task<List<ProductEntity>> ListAllAsync();
}