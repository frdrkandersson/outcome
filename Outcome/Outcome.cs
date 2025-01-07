namespace Outcome;

public class Outcome(OutcomeType type) : OutcomeBase(type)
{
    public static Outcome Success() => new(OutcomeType.Success);
    public static Outcome Failure(string? error = null) => new(OutcomeType.Failure) { Errors = string.IsNullOrWhiteSpace(error) ? [] : [error] };
    public static Outcome NotFound(string? error = null) => new(OutcomeType.NotFound) { Errors = string.IsNullOrWhiteSpace(error) ? [] : [error] };
    public static Outcome Invalid(params IEnumerable<ValidationError> errors) => new(OutcomeType.Invalid) { ValidationErrors = errors };
}
