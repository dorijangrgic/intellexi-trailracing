﻿using Intellexi.TrailRacing.Application.Common;
using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Application.Services;

namespace Intellexi.TrailRacing.Application.RaceManagement.Handlers;

public class RaceCreateRequestHandler(IMessageSender messageSender)
    : BaseRequestHandler<RaceCreateRequest>(messageSender);