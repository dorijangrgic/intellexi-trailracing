using FluentValidation;
using Intellexi.TrailRacing.Application.Common.ErrorHandling.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Intellexi.TrailRacing.Application.Common;

public class RequestValidationBehaviour<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IBaseRequest
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        ArgumentNullException.ThrowIfNull(validators);

        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        ValidationContext<TRequest> context = new(request);
        foreach (var validator in _validators)
        {
            await CheckInputParameters(validator, context, cancellationToken);
        }

        return await next();
    }

    protected static async Task CheckInputParameters<TValidator, TValidationContext>(
        TValidator validator,
        TValidationContext context,
        CancellationToken cancellationToken)
        where TValidator : IValidator
        where TValidationContext : IValidationContext
    {
        var validationResult = await validator.ValidateAsync(context, cancellationToken);

        if (validationResult.IsValid)
        {
            return;
        }

        ModelStateDictionary modelStateDictionary = new();

        foreach (var error in validationResult.Errors)
        {
            modelStateDictionary.AddModelError(error.PropertyName, error.ErrorMessage);
        }

        throw new BadRequestException(modelStateDictionary);
    }
}