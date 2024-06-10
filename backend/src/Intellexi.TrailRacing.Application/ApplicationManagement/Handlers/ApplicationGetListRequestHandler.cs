using Ardalis.GuardClauses;
using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;
using Intellexi.TrailRacing.Application.ApplicationManagement.Responses;
using Intellexi.TrailRacing.Application.Common;
using Intellexi.TrailRacing.Application.Services;
using MediatR;

namespace Intellexi.TrailRacing.Application.ApplicationManagement.Handlers;

public class ApplicationGetListRequestHandler : IRequestHandler<ApplicationGetListRequest, IEnumerable<ApplicationGetListResponse>>
{
    private readonly IRepository<Domain.Entities.Application> _applicationRepository;

    public ApplicationGetListRequestHandler(IRepository<Domain.Entities.Application> applicationRepository)
    {
        ArgumentNullException.ThrowIfNull(applicationRepository);
        _applicationRepository = applicationRepository;
    }

    public async Task<IEnumerable<ApplicationGetListResponse>> Handle(ApplicationGetListRequest request, CancellationToken cancellationToken)
    {
        var application = await _applicationRepository.ListAsync(cancellationToken);

        return application.Select(ApplicationGetListResponse.From);
    }
}