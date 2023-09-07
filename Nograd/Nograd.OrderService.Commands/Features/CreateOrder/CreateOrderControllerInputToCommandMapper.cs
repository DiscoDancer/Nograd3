namespace Nograd.OrderService.Commands.Features.CreateOrder
{
    public sealed class CreateOrderControllerInputToCommandMapper : ICreateOrderControllerInputToCommandMapper
    {
        public CreateOrderCommand Map(CreateOrderControllerInput input, Guid orderId)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (input.ProductQuantities == null) throw new ArgumentNullException(nameof(input.ProductQuantities));
            if (input.IsGift == null) throw new ArgumentNullException(nameof(input.IsGift));
            if (input.IsShipped == null) throw new ArgumentNullException(nameof(input.IsShipped));
            if (string.IsNullOrWhiteSpace(input.CustomerAddress)) throw new ArgumentNullException(nameof(input.CustomerAddress));
            if (string.IsNullOrWhiteSpace(input.CustomerName)) throw new ArgumentNullException(nameof(input.CustomerName));
            if (orderId == Guid.Empty) throw new ArgumentNullException(nameof(orderId));

            return new CreateOrderCommand(
                productQuantities: input.ProductQuantities.Select(Map).ToArray(),
                isShipped: input.IsShipped.Value,
                isGift: input.IsGift.Value,
                customerAddress: input.CustomerAddress,
                customerName: input.CustomerName,
                orderId: orderId);
        }

        private CreateOrderCommandProductQuantity Map(CreateOrderControllerInputProductQuantity input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (input.ProductId == null || input.ProductId == Guid.Empty) throw new ArgumentNullException(nameof(input.ProductId));
            if (input.Quantity == null || input.Quantity <= 0) throw new ArgumentNullException(nameof(input.Quantity));

            return new CreateOrderCommandProductQuantity(
                productId: input.ProductId.Value,
                quantity: input.Quantity.Value);
        }
    }
}
