using FluentValidation;
using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;

namespace Intellexi.TrailRacing.Application.ApplicationManagement.Validators;

public class ApplicationCreateRequestValidator : AbstractValidator<ApplicationCreateRequest>
{
    public ApplicationCreateRequestValidator()
    {
        RuleFor(x => x.RaceId)
            .NotEmpty();

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(MaxPropertyLength);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(MaxPropertyLength);
        
        RuleFor(x => x.Club)
            .NotEmpty()
            .MaximumLength(MaxPropertyLength);
    }
}