using Intellexi.TrailRacing.Application.Services;

namespace Intellexi.TrailRacing.RabbitMq;

public class MessageSender : IMessageSender
{
    public Task Send<T>(T message, string routingKey)
    {
        throw new NotImplementedException();
    }
}