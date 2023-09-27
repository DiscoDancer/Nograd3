using Microsoft.AspNetCore.Mvc;
using Nograd.Clients.CustomerApp.Models.Cart;

namespace Nograd.Clients.CustomerApp.Components;

public sealed class CartSummaryViewComponent : ViewComponent
{
    private readonly Cart _cart;

    public CartSummaryViewComponent(Cart cartService)
    {
        _cart = cartService;
    }

    public IViewComponentResult Invoke()
    {
        return View(_cart);
    }
}