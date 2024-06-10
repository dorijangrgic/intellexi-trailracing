using FluentValidation;
using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;

namespace Intellexi.TrailRacing.Application.ApplicationManagement.Validators;

public class ApplicationDeleteRequestValidator : AbstractValidator<ApplicationDeleteRequest>
{
    public ApplicationDeleteRequestValidator()
    {
        RuleFor(x => x.ApplicationId)
            .NotEmpty();
    }
}