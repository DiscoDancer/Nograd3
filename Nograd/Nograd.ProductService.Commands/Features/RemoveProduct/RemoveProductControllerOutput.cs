namespace Nograd.ProductService.Commands.Features.RemoveProduct
{
    public sealed class RemoveProductControllerOutput
    {
        public RemoveProductControllerOutput(Guid? id, string message)
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
