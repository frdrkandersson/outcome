using FluentValidation.Results;

namespace Outcome.MinimalApi.Extensions;

public static class FluentValidationExtensions
{
    public static IEnumerable<ValidationError> AsErrors(this List<ValidationFailure> validationFailures)
        => validationFailures.Select(x => new ValidationError(x.PropertyName, x.ErrorMessage));
}
