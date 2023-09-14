using Nograd.ProductService.Queries.Persistence.Entities;
using Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Controllers;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Mappers
{
    public interface IGetAllProductsMapper
    {
        public GetAllProductsExportProduct Map(ProductEntity product);
    }
}
