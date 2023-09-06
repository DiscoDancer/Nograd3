namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts
{
    public sealed class GetAllProductsErrorResponse
    {
        public GetAllProductsErrorResponse(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));

            Message = message;
        }

        public string Message { get; }
    }
}
