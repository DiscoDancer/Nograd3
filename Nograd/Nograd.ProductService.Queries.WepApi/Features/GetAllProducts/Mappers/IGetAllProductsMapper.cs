using Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Controllers;
using Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Queries;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Mappers;

public interface IGetAllProductsMapper
{
    public GetAllProductsOutput Map(GetAllProductsQueryOutput queryOutput);
}