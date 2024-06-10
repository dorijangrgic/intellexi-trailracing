using FluentValidation;
using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;

namespace Intellexi.TrailRacing.Application.ApplicationManagement.Validators;

public class ApplicationGetDetailsRequestValidator : AbstractValidator<ApplicationGetDetailsRequest>
{
    public ApplicationGetDetailsRequestValidator()
    {
        RuleFor(x => x.ApplicationId).NotEmpty();
    }
}