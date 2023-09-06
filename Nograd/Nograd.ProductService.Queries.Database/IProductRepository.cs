namespace Nograd.ProductService.Queries.Persistence
{
    public interface IProductRepository
    {
        Task CreateAsync(ProductEntity product);
        Task UpdateAsync(ProductEntity product);
        Task RemoveAsync(Guid productId);
        Task<ProductEntity?> GetByIdAsync(Guid productId);
        Task<List<ProductEntity>> ListAllAsync();
    }
}
