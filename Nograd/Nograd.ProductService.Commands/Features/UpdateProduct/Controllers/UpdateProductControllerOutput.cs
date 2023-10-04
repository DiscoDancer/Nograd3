namespace Nograd.ProductService.Commands.Features.UpdateProduct.Controllers;

[Serializable]
public sealed class UpdateProductControllerOutput
{
    public UpdateProductControllerOutput(Guid? id, string message)
    {
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));

        ProductId = id;
        Message = message;
    }

    public UpdateProductControllerOutput() {}

    public Guid? ProductId { get; set; }
    public string? Message { get; set; }
}