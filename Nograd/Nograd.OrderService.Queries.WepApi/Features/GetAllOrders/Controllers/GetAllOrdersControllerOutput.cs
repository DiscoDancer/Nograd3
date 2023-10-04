namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;

[Serializable]
public sealed class GetAllOrdersControllerOutput
{
    public List<GetAllOrdersControllerOutputOrder>? Orders { get; set; }
    public string? Message { get; set; }
}