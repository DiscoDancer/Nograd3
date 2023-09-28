using Nograd.OrderService.Commands.Features.CreateOrder.Controllers;

namespace Nograd.Clients.CustomerApp.Models.Order;

public sealed class OrderMapper : IOrderMapper
{
    public CreateOrderControllerInput Map(OrderViewModel model)
    {
        var input = new CreateOrderControllerInput
        {
            CustomerAddress = $"{model.Country} {model.State} {model.City} {model.Line1} {model.Line2} {model.Line3}",
            CustomerName = model.Name,
            Id = model.OrderID,
            IsGift = model.GiftWrap,
            IsShipped = model.Shipped,
            ProductQuantities = model.Lines.Select(line => new CreateOrderControllerInputProductQuantity
            {
                ProductId = line.Product.ProductID,
                Quantity = line.Quantity,
            }).ToArray()
        };

        return input;
    }
}