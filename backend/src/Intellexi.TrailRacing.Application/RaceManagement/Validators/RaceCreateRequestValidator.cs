using FluentValidation;
using Intellexi.TrailRacing.Application.RaceManagement.Requests;

namespace Intellexi.TrailRacing.Application.RaceManagement.Validators;

public class RaceCreateRequestValidator : AbstractValidator<RaceCreateRequest>
{
    public RaceCreateRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(MaxPropertyLength);
        
        RuleFor(x => x.Distance)
            .IsInEnum();
    }
}