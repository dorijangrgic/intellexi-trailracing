using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;
using Intellexi.TrailRacing.Application.Services;

namespace Intellexi.TrailRacing.QueryService.MessageHandlers.ApplicationHandlers;

public class ApplicationDeletedRequestHandler : IMessageHandler<ApplicationDeleteRequest>
{
    private readonly IGenericRepository<Domain.Entities.Application> _applicationRepository;

    public ApplicationDeletedRequestHandler(IGenericRepository<Domain.Entities.Application> applicationRepository)
    {
        ArgumentNullException.ThrowIfNull(applicationRepository);
        _applicationRepository = applicationRepository;
    }

    public async Task HandleAsync(ApplicationDeleteRequest message)
    {
        var existingApplication = await _applicationRepository.GetByIdAsync(message.ApplicationId);
        if (existingApplication is null) throw new Exception($"Application with id [{message.ApplicationId}] not found.");
        await _applicationRepository.DeleteAsync(existingApplication);
    }
}