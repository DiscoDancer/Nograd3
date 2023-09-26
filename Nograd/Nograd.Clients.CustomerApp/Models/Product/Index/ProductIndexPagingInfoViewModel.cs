namespace Nograd.Clients.CustomerApp.Models.Product.Index;

public sealed class ProductIndexPagingInfoViewModel
{
    public ProductIndexPagingInfoViewModel(
        int totalItems,
        int itemsPerPage,
        int currentPage)
    {
        if (totalItems < 0) throw new ArgumentOutOfRangeException(nameof(totalItems));
        if (itemsPerPage < 0) throw new ArgumentOutOfRangeException(nameof(itemsPerPage));
        if (currentPage < 0) throw new ArgumentOutOfRangeException(nameof(currentPage));

        TotalItems = totalItems;
        ItemsPerPage = itemsPerPage;
        CurrentPage = currentPage;
    }

    public int TotalItems { get; }
    public int ItemsPerPage { get; }
    public int CurrentPage { get; }

    public int TotalPages =>
        (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
}