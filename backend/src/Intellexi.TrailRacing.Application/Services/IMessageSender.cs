namespace Intellexi.TrailRacing.Application.Services;

public interface IMessageSender
{
    Task Send<T>(T message, string routingKey);
}