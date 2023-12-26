using FluentValidation;
using MediatR;
using ShopAppAPI.Application.Exceptions;
using ValidationException = ShopAppAPI.Application.Exceptions.ValidationException;

namespace ShopAppAPI.Application.Pipelines;

public class RequestValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
        => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<object>(request);
        
        IEnumerable<ValidationExceptionModel> validationErrors = _validators
            .Select(validator => validator.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .GroupBy(keySelector: p => p.PropertyName,
                     resultSelector: (propertyName, errors) =>
                     new ValidationExceptionModel { Property = propertyName, Errors = errors.Select(e => e.ErrorMessage) }
            ).ToList();

        if (validationErrors.Any())
            throw new ValidationException(validationErrors);

        TResponse response = await next();
        return response;
    }
}
