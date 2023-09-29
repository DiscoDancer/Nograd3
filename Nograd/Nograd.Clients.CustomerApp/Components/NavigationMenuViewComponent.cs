using Microsoft.AspNetCore.Mvc;
using Nograd.ProductService.Queries.Client;

namespace Nograd.Clients.CustomerApp.Components;

public sealed class NavigationMenuViewComponent : ViewComponent
{
    private readonly IProductQueriesClient _productClient;

    public NavigationMenuViewComponent(IProductQueriesClient productClient)
    {
        _productClient = productClient ?? throw new ArgumentNullException(nameof(productClient));
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.SelectedCategory = RouteData.Values["category"];

        var categories = await _productClient.GetAllCategoriesAsync();

        return View(categories);
    }
}