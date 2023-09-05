using Nograd.ProductServices.KafkaMessages;

namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure.KafkaConsumer
{
    public sealed class MessageHandler : IMessageHandler
    {
        public Task Handle(BaseMessage message)
        {
            return message switch
            {
                ProductCreatedMessage m => Handle(m),
                ProductUpdatedMessage m => Handle(m),
                ProductRemovedMessage m => Handle(m),
                _ => throw new NotImplementedException("Unrecognized message received."),
            };
        }

        private Task Handle(ProductCreatedMessage message)
        {
            throw new NotImplementedException();
        }
        private Task Handle(ProductUpdatedMessage message)
        {
            throw new NotImplementedException();
        }
        private Task Handle(ProductRemovedMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
