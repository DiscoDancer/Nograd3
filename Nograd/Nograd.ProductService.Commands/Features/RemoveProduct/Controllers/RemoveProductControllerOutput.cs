namespace Nograd.ProductService.Commands.Features.RemoveProduct.Controllers;

[Serializable]
public sealed class RemoveProductControllerOutput
{
    public RemoveProductControllerOutput(Guid? id, string message)
    {
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));

        ProductId = id;
        Message = message;
    }

    public RemoveProductControllerOutput()
    {

    }

    public Guid? ProductId { get; set; }
    public string? Message { get; set; }
}