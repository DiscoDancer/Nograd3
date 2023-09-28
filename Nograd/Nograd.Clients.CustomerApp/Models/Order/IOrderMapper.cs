using Nograd.OrderService.Commands.Features.CreateOrder.Controllers;

namespace Nograd.Clients.CustomerApp.Models.Order
{
    public interface IOrderMapper
    {
        CreateOrderControllerInput Map(OrderViewModel model);
    }
}
