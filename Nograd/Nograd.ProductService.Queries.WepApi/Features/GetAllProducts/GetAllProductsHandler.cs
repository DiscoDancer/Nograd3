using MediatR;
using Nograd.ProductService.Queries.Persistence;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts
{
    public sealed class GetAllProductsHandler: IRequestHandler<GetAllProductsQuery, IEnumerable<ProductEntity>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<ProductEntity>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.ListAllAsync();
        }
    }
}
