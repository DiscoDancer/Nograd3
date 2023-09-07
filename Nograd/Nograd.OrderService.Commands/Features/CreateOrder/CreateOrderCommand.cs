using MediatR;

namespace Nograd.OrderService.Commands.Features.CreateOrder
{
    public sealed class CreateOrderCommand: IRequest
    {
        public CreateOrderCommand(
            IReadOnlyCollection<CreateOrderCommandProductQuantity> productQuantities,
            bool isShipped,
            bool isGift,
            string customerName,
            string customerAddress,
            Guid orderId)
        {
            if (productQuantities == null || !productQuantities.Any()) throw new ArgumentNullException(nameof(productQuantities));
            if (string.IsNullOrWhiteSpace(customerName)) throw new ArgumentNullException(nameof(customerName));
            if (string.IsNullOrWhiteSpace(customerAddress)) throw new ArgumentNullException(nameof(customerAddress));
            if (orderId == Guid.Empty) throw new ArgumentNullException(nameof(orderId));

            ProductQuantities = productQuantities;
            IsShipped = isShipped;
            IsGift = isGift;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            OrderId = orderId;
        }


        public IReadOnlyCollection<CreateOrderCommandProductQuantity> ProductQuantities { get; }
        public bool IsShipped { get; }
        public bool IsGift { get; }
        public string CustomerName { get; }
        public string CustomerAddress { get; }
        public Guid OrderId { get; }
    }
}
