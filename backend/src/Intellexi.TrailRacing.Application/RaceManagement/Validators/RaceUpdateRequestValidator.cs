using FluentValidation;
using Intellexi.TrailRacing.Application.RaceManagement.Requests;

namespace Intellexi.TrailRacing.Application.RaceManagement.Validators;

public class RaceUpdateRequestValidator : AbstractValidator<RaceUpdateRequest>
{
    public RaceUpdateRequestValidator()
    {
        RuleFor(x => x.RaceId)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(MaxPropertyLength);
        
        RuleFor(x => x.Distance)
            .IsInEnum();
    }
}