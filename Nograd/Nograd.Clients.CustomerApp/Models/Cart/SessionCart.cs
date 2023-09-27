using System.Text.Json.Serialization;
using Nograd.Clients.CustomerApp.Infrastructure;
using Nograd.Clients.CustomerApp.Models.Product.Index;

namespace Nograd.Clients.CustomerApp.Models.Cart;

public sealed class SessionCart : Cart
{
    public static Cart GetCart(IServiceProvider services)
    {
        var session = services.GetRequiredService<IHttpContextAccessor>()
            .HttpContext?.Session;
        var cart = session?.GetJson<SessionCart>("Cart")
                   ?? new SessionCart();
        cart.Session = session;
        return cart;
    }

    [JsonIgnore] public ISession? Session { get; set; }

    public override void AddItem(ProductIndexProductViewModel product, int quantity)
    {
        base.AddItem(product, quantity);
        Session?.SetJson("Cart", this);
    }

    public override void RemoveLine(ProductIndexProductViewModel product)
    {
        base.RemoveLine(product);
        Session?.SetJson("Cart", this);
    }

    public override void Clear()
    {
        base.Clear();
        Session?.Remove("Cart");
    }
}