using Microsoft.AspNetCore.Mvc;

namespace Nograd.Clients.CustomerApp.Controllers;

public sealed class ProductController : Controller
{
    public async Task<ViewResult> Index(string? category, int productPage = 1)
    {
        return View();
    }
}