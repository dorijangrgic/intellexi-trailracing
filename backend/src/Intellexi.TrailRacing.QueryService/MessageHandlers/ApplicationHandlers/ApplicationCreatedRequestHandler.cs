using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;
using Intellexi.TrailRacing.Application.Services;

namespace Intellexi.TrailRacing.QueryService.MessageHandlers.ApplicationHandlers;

public class ApplicationCreatedRequestHandler : IMessageHandler<ApplicationCreateRequest>
{
    private readonly IRepository<Domain.Entities.Application> _applicationRepository;

    public ApplicationCreatedRequestHandler(IRepository<Domain.Entities.Application> applicationRepository)
    {
        ArgumentNullException.ThrowIfNull(applicationRepository);
        _applicationRepository = applicationRepository;
    }

    public async Task HandleAsync(ApplicationCreateRequest message)
    {
        var application = Domain.Entities.Application.Create(message.FirstName, message.LastName, message.Club, message.RaceId);
        await _applicationRepository.AddAsync(application);
    }
}