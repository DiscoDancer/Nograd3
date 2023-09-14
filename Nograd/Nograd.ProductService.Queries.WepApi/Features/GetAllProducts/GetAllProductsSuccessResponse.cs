namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts;

public sealed class GetAllProductsSuccessResponse
{
    public GetAllProductsSuccessResponse(List<GetAllProductsExportProduct> products, string message)
    {
        if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));
        if (products == null) throw new ArgumentNullException(nameof(products));

        Products = products;
        Message = message;
    }

    public List<GetAllProductsExportProduct> Products { get; }
    public string Message { get; }
}