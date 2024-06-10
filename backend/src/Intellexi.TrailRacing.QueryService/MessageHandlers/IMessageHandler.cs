namespace Intellexi.TrailRacing.QueryService.MessageHandlers;

public interface IMessageHandler<in T> where T : class
{
    Task HandleAsync(T message);
}