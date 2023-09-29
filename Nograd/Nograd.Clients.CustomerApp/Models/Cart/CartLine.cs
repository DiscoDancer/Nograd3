using Nograd.Clients.CustomerApp.Models.Product.Index;

namespace Nograd.Clients.CustomerApp.Models.Cart;

public sealed class CartLine
{
    public CartLine(ProductIndexProductViewModel product, int quantity)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));

        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

        Product = product;
        Quantity = quantity;
    }

    public void IncrementQuantity(int newQuantity)
    {
        if (newQuantity <= 0) throw new ArgumentOutOfRangeException(nameof(newQuantity));

        Quantity += newQuantity;
    }

    public ProductIndexProductViewModel Product { get; }
    public int Quantity { get; private set; }
}