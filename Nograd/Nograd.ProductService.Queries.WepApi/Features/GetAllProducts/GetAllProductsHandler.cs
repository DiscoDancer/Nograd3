using MediatR;
using Nograd.ProductService.Queries.Persistence.Entities;
using Nograd.ProductService.Queries.Persistence.Repositories;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts
{
    public sealed class GetAllProductsHandler: IRequestHandler<GetAllProductsQuery, IEnumerable<ProductEntity>>
    {
        private readonly IReadProductRepository _productRepository;

        public GetAllProductsHandler(IReadProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<ProductEntity>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.ListAllAsync();
        }
    }
}
