using Microsoft.EntityFrameworkCore;

namespace Nograd.ProductService.Queries.Persistence;

public sealed class ReadProductRepository : IReadProductRepository
{
    private readonly DatabaseContextFactory _contextFactory;

    public ReadProductRepository(DatabaseContextFactory contextFactory)
    {
        _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    public async Task<ProductEntity?> GetByIdAsync(Guid productId)
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Products
            .FirstOrDefaultAsync(x => x.ProductId == productId);
    }

    public async Task<List<ProductEntity>> ListAllAsync()
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Products.AsNoTracking()
            .ToListAsync();
    }
}