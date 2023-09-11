namespace Nograd.ProductService.Commands.Features.UpdateProduct.Controllers
{
    public sealed class UpdateProductControllerOutput
    {
        public UpdateProductControllerOutput(Guid? id, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            ProductId = id;
            Message = message;
        }

        public Guid? ProductId { get; }
        public string Message { get; }
    }
}
