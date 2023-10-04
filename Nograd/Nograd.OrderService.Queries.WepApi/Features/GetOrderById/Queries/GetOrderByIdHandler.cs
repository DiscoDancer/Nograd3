using MediatR;
using Nograd.OrderService.Queries.Persistence.Entities;
using Nograd.OrderService.Queries.Persistence.Repositories.Order;

namespace Nograd.OrderService.Queries.WepApi.Features.GetOrderById.Queries;

public sealed class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderEntity?>
{
    private readonly IReadOrderRepository _orderRepository;

    public GetOrderByIdHandler(IReadOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<OrderEntity?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetByIdAsync(request.OrderId);
    }
}