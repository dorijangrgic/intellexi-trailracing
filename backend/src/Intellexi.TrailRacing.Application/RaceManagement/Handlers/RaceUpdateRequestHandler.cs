using Intellexi.TrailRacing.Application.Common;
using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Application.Services;

namespace Intellexi.TrailRacing.Application.RaceManagement.Handlers;

public class RaceUpdateRequestHandler(IMessageSender messageSender)
    : BaseRequestHandler<RaceUpdateRequest>(messageSender);