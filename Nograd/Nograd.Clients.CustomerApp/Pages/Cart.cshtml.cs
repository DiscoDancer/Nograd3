using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nograd.Clients.CustomerApp.Models.Cart;
using Nograd.Clients.CustomerApp.Models.Product.Index;
using Nograd.ProductService.Queries.Client;

namespace Nograd.Clients.CustomerApp.Pages;

public class CartModel : PageModel
{
    private readonly IProductQueriesClient _productQueriesClient;

    public CartModel(IProductQueriesClient productClient, Cart cartService)
    {
        _productQueriesClient = productClient ?? throw new ArgumentNullException(nameof(productClient));
        Cart = cartService ?? throw new ArgumentNullException(nameof(cartService));
    }

    public Cart Cart { get; set; }
    public string ReturnUrl { get; set; } = "/";

    public void OnGet(string returnUrl)
    {
        ReturnUrl = returnUrl ?? "/";
    }

    public async Task<IActionResult> OnPost(Guid productId, string returnUrl)
    {
        if (productId == Guid.Empty)
        {
            throw new ArgumentOutOfRangeException(nameof(productId));
        }

        var product = await _productQueriesClient.GetProductByIdOrDefaultAsync(productId);

        if (product == null)
        {
            throw new ArgumentException(nameof(productId));
        }

        var domainProduct = new ProductIndexProductViewModel(
            name: product.Name,
            description: product.Description,
            price: product.Price,
            category: product.Category,
            productId: product.ProductId);


        Cart.AddItem(domainProduct, 1);
        return RedirectToPage(new { returnUrl });
    }

    public IActionResult OnPostRemove(Guid productId, string returnUrl)
    {
        if (productId == Guid.Empty)
        {
            throw new ArgumentOutOfRangeException(nameof(productId));
        }

        Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductID == productId).Product);
        return RedirectToPage(new { returnUrl });
    }
}