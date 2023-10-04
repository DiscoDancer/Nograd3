using Nograd.OrderService.Queries.Persistence.Entities;
using Nograd.OrderService.Queries.WepApi.Features.GetOrderById.Controllers;

namespace Nograd.OrderService.Queries.WepApi.Features.GetOrderById.Mappers;

public interface IGetOrderByIdMapper
{
    GetOrderByIdControllerOutputOrder Map(OrderEntity order);
}