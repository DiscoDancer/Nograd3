using MediatR;
using Nograd.OrderService.Queries.Persistence.Entities;
using Nograd.OrderService.Queries.Persistence.Repositories;

namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Queries;

public sealed class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderEntity>>
{
    private readonly IReadOrderRepository _orderRepository;

    public GetAllOrdersHandler(IReadOrderRepository productRepository)
    {
        _orderRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<IEnumerable<OrderEntity>> Handle(GetAllOrdersQuery request,
        CancellationToken cancellationToken)
    {
        return await _orderRepository.ListAllAsync();
    }
}