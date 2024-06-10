using Ardalis.GuardClauses;
using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;
using Intellexi.TrailRacing.Application.ApplicationManagement.Responses;
using Intellexi.TrailRacing.Application.Common;
using Intellexi.TrailRacing.Application.Services;
using MediatR;

namespace Intellexi.TrailRacing.Application.ApplicationManagement.Handlers;

public class ApplicationGetDetailsRequestHandler : IRequestHandler<ApplicationGetDetailsRequest, ApplicationGetDetailsResponse>
{
    private readonly IRepository<Domain.Entities.Application> _applicationRepository;

    public ApplicationGetDetailsRequestHandler(IRepository<Domain.Entities.Application> applicationRepository)
    {
        ArgumentNullException.ThrowIfNull(applicationRepository);
        _applicationRepository = applicationRepository;
    }

    public async Task<ApplicationGetDetailsResponse> Handle(ApplicationGetDetailsRequest request, CancellationToken cancellationToken)
    {
        var application = await _applicationRepository.GetByIdAsync(request.ApplicationId, cancellationToken);
        
        Guard.Against.EntityNotFound(application, request.ApplicationId);
        
        return ApplicationGetDetailsResponse.From(application);
    }
}