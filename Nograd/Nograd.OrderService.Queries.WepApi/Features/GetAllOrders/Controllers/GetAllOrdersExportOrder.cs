namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;

public sealed class GetAllOrdersExportOrder
{
    public GetAllOrdersExportOrder(
        Guid orderId,
        string customerAddress,
        string customerName,
        bool isGift,
        bool isShipped,
        IReadOnlyCollection<GetAllOrdersExportOrderProductQuantity> productQuantities)
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
    }


    public IReadOnlyCollection<GetAllOrdersExportOrderProductQuantity> ProductQuantities { get; }
    public bool IsShipped { get; }
    public bool IsGift { get; }
    public string CustomerName { get; }
    public string CustomerAddress { get; }
    public Guid OrderId { get; }
}