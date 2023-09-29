using Microsoft.AspNetCore.Mvc;
using Nograd.Clients.CustomerApp.Models.Product.Index;
using Nograd.ProductService.Queries.Client;

namespace Nograd.Clients.CustomerApp.Controllers;

public sealed class ProductController : Controller
{
    private readonly IProductQueriesClient _productQueriesClient;
    private readonly IProductIndexMapper _mapper;
    public const int PageSize = 4;

    public ProductController(IProductQueriesClient productQueriesClient,
        IProductIndexMapper mapper)
    {
        _productQueriesClient = productQueriesClient ?? throw new ArgumentNullException(nameof(productQueriesClient));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ViewResult> Index(string? category, int productPage = 1)
    {
        var response = await _productQueriesClient.GetAllProductsAsync();

        var products = response.Products;
        var total = response.TotalWithSelectedCategory;

        var pagingInfo = new ProductIndexPagingInfoViewModel(
            currentPage: productPage,
            itemsPerPage: PageSize,
            totalItems: total);

        var vm = new ProductIndexViewModel(
            products.Select(_mapper.Map).ToArray(),
            pagingInfo,
            category);

        return View(vm);
    }
}