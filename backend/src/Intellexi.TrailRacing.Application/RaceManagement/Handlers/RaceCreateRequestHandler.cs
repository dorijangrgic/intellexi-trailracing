using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Application.Services;
using MediatR;

namespace Intellexi.TrailRacing.Application.RaceManagement.Handlers;

public class RaceCreateRequestHandler : IRequestHandler<RaceCreateRequest>
{
    private readonly IMessageSender _messageSender;

    public RaceCreateRequestHandler(IMessageSender messageSender)
    {
        ArgumentNullException.ThrowIfNull(messageSender);
        _messageSender = messageSender;
    }

    public async Task Handle(RaceCreateRequest request, CancellationToken cancellationToken)
    {
        await _messageSender.Send(request, "race_create");
    }
}