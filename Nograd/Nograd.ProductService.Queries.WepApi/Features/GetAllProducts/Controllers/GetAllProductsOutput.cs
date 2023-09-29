namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Controllers;

public sealed class GetAllProductsOutput
{
    public GetAllProductsOutput(
        int totalWithSelectedCategory,
        IReadOnlyCollection<GetAllProductsExportProduct> products)
    {
        if (totalWithSelectedCategory < 0) throw new ArgumentOutOfRangeException(nameof(totalWithSelectedCategory));
        if (products == null) throw new ArgumentNullException(nameof(products));

        TotalWithSelectedCategory = totalWithSelectedCategory;
        Products = products;
    }

    public IReadOnlyCollection<GetAllProductsExportProduct> Products { get; }
    public int TotalWithSelectedCategory { get; }
}