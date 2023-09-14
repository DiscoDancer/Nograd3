using Microsoft.EntityFrameworkCore;
using Nograd.OrderService.Queries.Persistence.Context;
using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.Persistence.Repositories.Product;

public sealed class ReadProductRepository : IReadProductRepository
{
    private readonly IDbContextFactory<DatabaseContext> _contextFactory;

    public ReadProductRepository(IDbContextFactory<DatabaseContext> contextFactory)
    {
        _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    public async Task<ProductEntity?> GetByIdAsync(Guid productId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context
            .Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ProductId == productId);
    }

    public async Task<List<ProductEntity>> ListAllAsync()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context
            .Products
            .AsNoTracking()
            .ToListAsync();
    }
}