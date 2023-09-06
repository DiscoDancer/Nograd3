namespace Nograd.ProductService.Queries.Persistence;

public interface IReadProductRepository
{
    Task<ProductEntity?> GetByIdAsync(Guid productId);
    Task<List<ProductEntity>> ListAllAsync();
}