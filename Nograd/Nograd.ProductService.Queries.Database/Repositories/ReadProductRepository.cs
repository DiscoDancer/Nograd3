using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Nograd.ProductService.Queries.Persistence.Context;
using Nograd.ProductService.Queries.Persistence.Entities;

namespace Nograd.ProductService.Queries.Persistence.Repositories;

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

    public async Task<List<ProductEntity>> ListAllAsync(int? take = null, int? skip = null, string? category = null)
    {
        if (take == null && skip != null || take != null && skip == null)
        {
            throw new Exception("take and skip must be both null or both provided.");
        }


        await using var context = await _contextFactory.CreateDbContextAsync();

        var baseExpression = context
            .Products
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(category))
        {
            baseExpression = baseExpression.Where(p => p.Category == category);
        }
        if (take != null && skip != null)
        {
            baseExpression = baseExpression
                .Skip(skip.Value)
                .Take(take.Value);
        }

        return await baseExpression
            .ToListAsync();
    }

    public async Task<int> Count(string? category)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        if (string.IsNullOrWhiteSpace(category))
        {
            return await context
                .Products
                .CountAsync();
        }

        return await context
            .Products
            .Where(p => p.Category == category)
            .CountAsync();
    }
}