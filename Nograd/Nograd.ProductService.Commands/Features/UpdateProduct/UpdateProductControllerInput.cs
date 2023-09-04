namespace Nograd.ProductService.Commands.Features.UpdateProduct;

public sealed class UpdateProductControllerInput
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public decimal Price { get; set; }
    public Guid? ProductId { get; set; }
}