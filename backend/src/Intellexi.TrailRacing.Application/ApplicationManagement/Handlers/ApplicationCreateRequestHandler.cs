using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;
using Intellexi.TrailRacing.Application.Common;
using Intellexi.TrailRacing.Application.Services;

namespace Intellexi.TrailRacing.Application.ApplicationManagement.Handlers;

public class ApplicationCreateRequestHandler(IMessageSender messageSender)
    : BaseRequestHandler<ApplicationCreateRequest>(messageSender);