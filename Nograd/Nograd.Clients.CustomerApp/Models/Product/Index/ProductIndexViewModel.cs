namespace Nograd.Clients.CustomerApp.Models.Product.Index;

public sealed class ProductIndexViewModel
{
    public ProductIndexViewModel(
        IEnumerable<ProductIndexProductViewModel> products,
        ProductIndexPagingInfoViewModel pagingInfo,
        string? currentCategory)
    {
        Products = products ?? throw new ArgumentNullException(nameof(products));
        PagingInfo = pagingInfo ?? throw new ArgumentNullException(nameof(pagingInfo));
        CurrentCategory = currentCategory;
    }

    public IEnumerable<ProductIndexProductViewModel> Products { get; }
    public ProductIndexPagingInfoViewModel PagingInfo { get; }
    public string? CurrentCategory { get; }
}