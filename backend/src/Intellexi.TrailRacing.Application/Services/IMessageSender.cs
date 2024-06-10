namespace Intellexi.TrailRacing.Application.Services;

public interface IMessageSender
{
    void Send<T>(T message);
}