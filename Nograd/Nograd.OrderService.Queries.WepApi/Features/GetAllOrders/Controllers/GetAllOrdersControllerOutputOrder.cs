namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;

[Serializable]
public sealed class GetAllOrdersControllerOutputOrder
{
    public GetAllOrdersControllerOutputOrder(
        Guid orderId,
        string customerAddress,
        string customerName,
        bool isGift,
        bool isShipped,
        IReadOnlyCollection<GetAllOrdersControllerOutputProductQuantity> productQuantities)
    {
        if (orderId == Guid.Empty) throw new ArgumentNullException(nameof(orderId));
        if (string.IsNullOrWhiteSpace(customerName)) throw new ArgumentNullException(nameof(customerName));
        if (string.IsNullOrWhiteSpace(customerAddress)) throw new ArgumentNullException(nameof(customerAddress));
        if (productQuantities == null || !productQuantities.Any())
            throw new ArgumentNullException(nameof(productQuantities));

        OrderId = orderId;
        CustomerAddress = customerAddress;
        CustomerName = customerName;
        IsGift = isGift;
        IsShipped = isShipped;
        ProductQuantities = productQuantities;

        foreach (var pq in ProductQuantities)
        {
            if (pq.Product?.Price == null)
            {
                throw new ArgumentNullException(nameof(productQuantities));
            }

            Total += pq.Product.Price * pq.Quantity;
        }
    }

    public GetAllOrdersControllerOutputOrder()
    {

    }


    public IReadOnlyCollection<GetAllOrdersControllerOutputProductQuantity>? ProductQuantities { get; set; }
    public bool? IsShipped { get; set; }
    public bool? IsGift { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerAddress { get; set; }
    public Guid? OrderId { get; set; }
    public decimal? Total { get; set; }
}