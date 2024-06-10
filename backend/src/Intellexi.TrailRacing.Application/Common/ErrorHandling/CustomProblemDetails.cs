using Microsoft.AspNetCore.Mvc;

namespace Intellexi.TrailRacing.Application.Common.ErrorHandling;

public class CustomProblemDetails : ProblemDetails
{
    public Dictionary<string, string[]> Errors { get; set; } = new();
}
