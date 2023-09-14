namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers
{
    public sealed class GetAllOrdersErrorResponse
    {
        public GetAllOrdersErrorResponse(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));

            Message = message;
        }

        public string Message { get; }
    }
}
