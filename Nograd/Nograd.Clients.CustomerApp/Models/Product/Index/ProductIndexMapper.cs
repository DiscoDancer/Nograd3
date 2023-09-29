using Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Controllers;

namespace Nograd.Clients.CustomerApp.Models.Product.Index;

public sealed class ProductIndexMapper : IProductIndexMapper
{
    public ProductIndexProductViewModel Map(GetAllProductsExportProduct product)
    {
        if (product.ProductId == Guid.Empty) throw new ArgumentException(nameof(product.ProductId));
        if (string.IsNullOrWhiteSpace(product.Category)) throw new ArgumentNullException(nameof(product.Category));
        if (string.IsNullOrWhiteSpace(product.Name)) throw new ArgumentNullException(nameof(product.Name));
        if (string.IsNullOrWhiteSpace(product.Description)) throw new ArgumentNullException(nameof(product.Description));
        if (product.Price <= 0) throw new ArgumentOutOfRangeException(nameof(product.Price));

        return new ProductIndexProductViewModel(
            productId: product.ProductId,
            name: product.Name,
            description: product.Description,
            price: product.Price,
            category: product.Category);
    }
}