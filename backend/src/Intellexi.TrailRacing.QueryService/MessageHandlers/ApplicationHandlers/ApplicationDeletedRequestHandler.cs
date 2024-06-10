using Ardalis.GuardClauses;
using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;
using Intellexi.TrailRacing.Application.Common;
using Intellexi.TrailRacing.Application.Services;

namespace Intellexi.TrailRacing.QueryService.MessageHandlers.ApplicationHandlers;

public class ApplicationDeletedRequestHandler : IMessageHandler<ApplicationDeleteRequest>
{
    private readonly IRepository<Domain.Entities.Application> _applicationRepository;

    public ApplicationDeletedRequestHandler(IRepository<Domain.Entities.Application> applicationRepository)
    {
        ArgumentNullException.ThrowIfNull(applicationRepository);
        _applicationRepository = applicationRepository;
    }

    public async Task HandleAsync(ApplicationDeleteRequest message)
    {
        var application = await _applicationRepository.GetByIdAsync(message.ApplicationId);
        
        Guard.Against.EntityNotFound(application, message.ApplicationId);
        
        await _applicationRepository.DeleteAsync(application);
    }
}