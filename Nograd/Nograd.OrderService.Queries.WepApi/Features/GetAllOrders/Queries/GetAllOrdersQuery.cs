using MediatR;
using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Queries;

public sealed record GetAllOrdersQuery : IRequest<IEnumerable<OrderEntity>>;