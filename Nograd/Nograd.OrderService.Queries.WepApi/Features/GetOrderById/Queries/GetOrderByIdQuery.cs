using MediatR;
using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.WepApi.Features.GetOrderById.Queries;

public sealed record GetOrderByIdQuery(Guid OrderId) : IRequest<OrderEntity?>;