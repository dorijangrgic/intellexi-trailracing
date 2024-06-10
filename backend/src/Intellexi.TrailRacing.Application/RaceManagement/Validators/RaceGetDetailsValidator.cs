using FluentValidation;
using Intellexi.TrailRacing.Application.RaceManagement.Requests;

namespace Intellexi.TrailRacing.Application.RaceManagement.Validators;

public class RaceGetDetailsValidator : AbstractValidator<RaceGetDetailsRequest>
{
    public RaceGetDetailsValidator()
    {
        RuleFor(x => x.RaceId).NotEmpty();
    }
}