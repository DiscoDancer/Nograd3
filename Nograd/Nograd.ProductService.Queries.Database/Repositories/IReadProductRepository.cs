using Nograd.ProductService.Queries.Persistence.Entities;

namespace Nograd.ProductService.Queries.Persistence.Repositories;

public interface IReadProductRepository
{
    Task<ProductEntity?> GetByIdAsync(Guid productId);
    Task<List<ProductEntity>> ListAllAsync(int? take = null, int? skip = null, string? category = null);
    public Task<int> CountAsync(string? category);
    public Task<IReadOnlyCollection<string>> GetAllCategoriesAsync();
}