using Microsoft.EntityFrameworkCore;
using Nograd.OrderService.Queries.Persistence.Context;
using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.Persistence.Repositories.Product;

public sealed class WriteProductRepository : IWriteProductRepository
{
    private readonly IDbContextFactory<DatabaseContext> _contextFactory;

    public WriteProductRepository(IDbContextFactory<DatabaseContext> contextFactory)
    {
        _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    public async Task CreateAsync(ProductEntity product)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        context.Products.Add(product);
        _ = await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductEntity product)
    {
        await RemoveAsync(product.ProductId);
        await CreateAsync(product);
    }

    public async Task RemoveAsync(Guid productId)
    {
        var foundOrder = await GetByIdAsync(productId);
        if (foundOrder == null) throw new Exception("product not found");

        await using var context = await _contextFactory.CreateDbContextAsync();
        context.Products.Remove(foundOrder);
        _ = await context.SaveChangesAsync();
    }

    private async Task<ProductEntity?> GetByIdAsync(Guid productId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context
            .Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ProductId == productId);
    }
}