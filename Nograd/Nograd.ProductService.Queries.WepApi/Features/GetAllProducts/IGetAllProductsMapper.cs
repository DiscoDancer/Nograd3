using Nograd.ProductService.Queries.Persistence;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts
{
    public interface IGetAllProductsMapper
    {
        public GetAllProductsExportProduct Map(ProductEntity  product);
    }
}
