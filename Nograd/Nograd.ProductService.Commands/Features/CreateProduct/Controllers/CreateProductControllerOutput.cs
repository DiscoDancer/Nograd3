namespace Nograd.ProductService.Commands.Features.CreateProduct.Controllers;

[Serializable]
public sealed class CreateProductControllerOutput
{
    public CreateProductControllerOutput(Guid id, string message)
    {
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));

        ProductId = id;
        Message = message;
    }

    public CreateProductControllerOutput() {}

    public Guid? ProductId { get; set; }
    public string? Message { get; set; }
}