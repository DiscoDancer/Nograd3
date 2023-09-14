using Nograd.ProductService.Queries.Persistence.Entities;
using Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Controllers;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Mappers
{
    public sealed class GetAllProductsMapper : IGetAllProductsMapper
    {
        public GetAllProductsExportProduct Map(ProductEntity product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (string.IsNullOrWhiteSpace(product.Name)) throw new ArgumentNullException(nameof(product.Name));
            if (string.IsNullOrWhiteSpace(product.Description)) throw new ArgumentNullException(nameof(product.Description));
            if (string.IsNullOrWhiteSpace(product.Category)) throw new ArgumentNullException(nameof(product.Category));
            if (product.Price <= 0) throw new ArgumentNullException(nameof(product.Price));
            if (product.ProductId == Guid.Empty) throw new ArgumentNullException(nameof(product.ProductId));

            return new GetAllProductsExportProduct(
                name: product.Name,
                category: product.Category,
                description: product.Description,
                productId: product.ProductId,
                price: product.Price);
        }
    }
}
