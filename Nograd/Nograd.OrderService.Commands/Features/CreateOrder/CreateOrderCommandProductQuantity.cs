﻿namespace Nograd.OrderService.Commands.Features.CreateOrder
{
    public sealed class CreateOrderCommandProductQuantity
    {
        public CreateOrderCommandProductQuantity (Guid productId, int quantity)
        {
            if (productId == Guid.Empty) throw new ArgumentException(nameof(productId));
            if (quantity <= 0) throw new ArgumentException(nameof(quantity));

            ProductId = productId;
            Quantity = quantity;
        }

        public Guid ProductId { get; }
        public int Quantity { get; }
    }
}
