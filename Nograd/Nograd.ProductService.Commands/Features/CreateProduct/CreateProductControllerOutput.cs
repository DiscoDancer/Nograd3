namespace Nograd.ProductService.Commands.Features.CreateProduct
{
    public sealed class CreateProductControllerOutput
    {
        public CreateProductControllerOutput(Guid id, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            ProductId = id;
            Message = message;
        }

        public Guid ProductId { get; }
        public string Message { get; }
    }
}
