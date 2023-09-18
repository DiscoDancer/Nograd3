using Nograd.ProductService.Queries.Persistence.Entities;
using Nograd.ProductService.Queries.WepApi.Features.GetProductById.Controllers;

namespace Nograd.ProductService.Queries.WepApi.Features.GetProductById.Mappers;

public interface IGetProductByIdMapper
{
    public GetProductByIdExportProduct Map(ProductEntity product);
}