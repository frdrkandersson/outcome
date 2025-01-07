namespace Outcome;

public record ValidationError(string PropertyName, string ErrorMessage);