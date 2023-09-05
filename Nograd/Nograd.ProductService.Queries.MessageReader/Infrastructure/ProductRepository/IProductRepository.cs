namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure.ProductRepository
{
    public interface IProductRepository
    {
        Task CreateAsync(ProductEntity product);
        Task UpdateAsync(ProductEntity product);
        Task RemoveAsync(Guid productId);
        Task<ProductEntity?> GetByIdAsync(Guid productId);
    }
}
