using Intellexi.TrailRacing.Application.Services;
using MediatR;

namespace Intellexi.TrailRacing.Application.Common;

public abstract class BaseRequestHandler<T> : IRequestHandler<T> where T : IRequest
{
    private readonly IMessageSender _messageSender;

    protected BaseRequestHandler(IMessageSender messageSender)
    {
        ArgumentNullException.ThrowIfNull(messageSender);
        _messageSender = messageSender;
    }

    public Task Handle(T request, CancellationToken cancellationToken)
    {
        _messageSender.Send(request);
        return Task.CompletedTask;
    }
}