using Nograd.ProductService.Queries.Persistence.Context;
using Nograd.ProductService.Queries.Persistence.Entities;

namespace Nograd.ProductService.Queries.Persistence.Repositories;

public sealed class WriteProductRepository : IWriteProductRepository
{
    private readonly DatabaseContextFactory _contextFactory;
    private readonly IReadProductRepository _readProductRepository;

    public WriteProductRepository(DatabaseContextFactory contextFactory, IReadProductRepository readProductRepository)
    {
        _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        _readProductRepository = readProductRepository ?? throw new ArgumentNullException(nameof(readProductRepository));
    }

    public async Task CreateAsync(ProductEntity product)
    {
        await using var context = _contextFactory.CreateDbContext();
        context.Products.Add(product);

        _ = await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductEntity product)
    {
        var foundProduct = await _readProductRepository.GetByIdAsync(product.ProductId);
        if (foundProduct == null) throw new Exception("product not found");

        await using var context = _contextFactory.CreateDbContext();
        context.Products.Update(product);

        _ = await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Guid productId)
    {
        var foundProduct = await _readProductRepository.GetByIdAsync(productId);
        if (foundProduct == null) throw new Exception("product not found");

        await using var context = _contextFactory.CreateDbContext();
        context.Products.Remove(foundProduct);
        _ = await context.SaveChangesAsync();
    }
}