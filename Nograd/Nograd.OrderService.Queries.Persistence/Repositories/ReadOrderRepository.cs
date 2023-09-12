using Microsoft.EntityFrameworkCore;
using Nograd.OrderService.Queries.Persistence.Context;
using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.Persistence.Repositories;

public sealed class ReadOrderRepository : IReadOrderRepository
{
    private readonly DatabaseContext _databaseContext;

    public ReadOrderRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
    }

    public async Task<OrderEntity?> GetByIdAsync(Guid orderId)
    {
        return await _databaseContext
            .Orders
            .Include(x => x.ProductQuantities)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.OrderId == orderId);
    }

    public async Task<List<OrderEntity>> ListAllAsync()
    {
        return await _databaseContext
            .Orders
            .Include(x => x.ProductQuantities)
            .AsNoTracking()
            .ToListAsync();
    }
}