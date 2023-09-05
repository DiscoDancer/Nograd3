using Microsoft.EntityFrameworkCore;

namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure.ProductRepository
{
    public sealed class ProductRepository: IProductRepository
    {
        private readonly DatabaseContextFactory _contextFactory;

        public ProductRepository(DatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public async Task CreateAsync(ProductEntity product)
        {
            await using var context = _contextFactory.CreateDbContext();
            context.Products.Add(product);

            _ = await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductEntity product)
        {
            await using var context = _contextFactory.CreateDbContext();
            context.Products.Update(product);

            _ = await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid productId)
        {
            await using var context = _contextFactory.CreateDbContext();
            var post = await GetByIdAsync(productId);

            if (post == null) return;

            context.Products.Remove(post);
            _ = await context.SaveChangesAsync();
        }

        public async Task<ProductEntity?> GetByIdAsync(Guid productId)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Products
                .FirstOrDefaultAsync(x => x.ProductId == productId);
        }
    }
}
