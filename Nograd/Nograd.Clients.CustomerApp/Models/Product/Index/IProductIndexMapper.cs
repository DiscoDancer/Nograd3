using Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Controllers;

namespace Nograd.Clients.CustomerApp.Models.Product.Index
{
    public interface IProductIndexMapper
    {
        ProductIndexProductViewModel Map(GetAllProductsExportProduct product);
    }
}
