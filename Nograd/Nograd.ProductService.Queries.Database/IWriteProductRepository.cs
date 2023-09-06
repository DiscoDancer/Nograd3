namespace Nograd.ProductService.Queries.Persistence;

public interface IWriteProductRepository
{
    Task CreateAsync(ProductEntity product);
    Task UpdateAsync(ProductEntity product);
    Task RemoveAsync(Guid productId);
}