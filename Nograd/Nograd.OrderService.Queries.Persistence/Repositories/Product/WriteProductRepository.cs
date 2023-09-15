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
        await using var context = await _contextFactory.CreateDbContextAsync();
        await using var dbContextTransaction = await context.Database.BeginTransactionAsync();

        var foundProduct = await GetByIdAsync(product.ProductId, context);
        if (foundProduct == null) throw new Exception("product not found");
        context.Products.Remove(foundProduct);
        context.Products.Add(product);

        _ = await context.SaveChangesAsync();
        await dbContextTransaction.CommitAsync();
    }

    public async Task RemoveAsync(Guid productId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        var foundProduct = await GetByIdAsync(productId, context);
        if (foundProduct == null) throw new Exception("product not found");

        context.Products.Remove(foundProduct);
        _ = await context.SaveChangesAsync();
    }

    private static async Task<ProductEntity?> GetByIdAsync(Guid productId, DatabaseContext existingContext)
    {
        return await existingContext
            .Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ProductId == productId);
    }
}