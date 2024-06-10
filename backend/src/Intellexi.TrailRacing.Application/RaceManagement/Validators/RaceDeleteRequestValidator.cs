using FluentValidation;
using Intellexi.TrailRacing.Application.RaceManagement.Requests;

namespace Intellexi.TrailRacing.Application.RaceManagement.Validators;

public class RaceDeleteRequestValidator : AbstractValidator<RaceDeleteRequest>
{
    public RaceDeleteRequestValidator()
    {
        RuleFor(x => x.RaceId)
            .NotEmpty();
    }
}