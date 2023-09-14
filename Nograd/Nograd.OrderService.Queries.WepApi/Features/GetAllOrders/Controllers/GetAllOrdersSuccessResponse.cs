namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;

public sealed class GetAllOrdersSuccessResponse
{
    public GetAllOrdersSuccessResponse(List<GetAllOrdersExportOrder> orders, string message)
    {
        if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));
        if (orders == null) throw new ArgumentNullException(nameof(orders));

        Orders = orders;
        Message = message;
    }

    public List<GetAllOrdersExportOrder> Orders { get; }
    public string Message { get; }
}