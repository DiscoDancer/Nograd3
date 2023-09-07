namespace Nograd.OrderService.Commands.Features.CreateOrder
{
    public sealed class CreateOrderControllerOutput
    {
        public CreateOrderControllerOutput(Guid id, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            OrderId = id;
            Message = message;
        }

        public Guid OrderId { get; }
        public string Message { get; }
    }
}
