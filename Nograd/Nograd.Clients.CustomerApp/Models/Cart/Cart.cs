using Nograd.Clients.CustomerApp.Models.Product.Index;

namespace Nograd.Clients.CustomerApp.Models.Cart;

public class Cart
{
    // set is important for deserialization
    public List<CartLine> Lines { get; set; } = new();

    public virtual void AddItem(ProductIndexProductViewModel product, int quantity)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));

        if (quantity < 0) throw new ArgumentOutOfRangeException(nameof(quantity));

        var line = Lines.FirstOrDefault(p => p.Product.ProductID == product.ProductID);

        if (line == null)
        {
            if (quantity == 0) throw new ArgumentOutOfRangeException(nameof(quantity));

            Lines.Add(new CartLine(product, quantity));
            return;
        }

        if (quantity > 0)
            line.IncrementQuantity(quantity);
        else if (quantity == 0) Lines.Remove(line);
    }

    public virtual void RemoveLine(ProductIndexProductViewModel product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));  
        
        Lines.RemoveAll(l => l.Product.ProductID == product.ProductID);
    }

    public decimal ComputeTotalValue()
    {
        return Lines.Sum(e => e.Product.Price * e.Quantity);
    }

    public virtual void Clear()
    {
        Lines.Clear();
    }
}