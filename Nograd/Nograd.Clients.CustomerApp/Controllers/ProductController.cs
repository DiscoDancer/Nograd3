using Microsoft.AspNetCore.Mvc;
using Nograd.ProductService.Queries.Client;

namespace Nograd.Clients.CustomerApp.Controllers;

public sealed class ProductController : Controller
{
    private readonly IProductQueriesClient _productQueriesClient;

    public ProductController(IProductQueriesClient productQueriesClient)
    {
        _productQueriesClient = productQueriesClient ?? throw new ArgumentNullException(nameof(productQueriesClient));
    }

    public async Task<ViewResult> Index(string? category, int productPage = 1)
    {
        var products = await _productQueriesClient.GetAllProductsAsync();

        return View();
    }
}