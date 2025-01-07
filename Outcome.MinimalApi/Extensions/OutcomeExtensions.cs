using Microsoft.AspNetCore.Mvc;

namespace Outcome.MinimalApi.Extensions;

public static class OutcomeExtensions
{
    public static IResult ToResult(this OutcomeBase result) => result.Type switch
    {
        OutcomeType.Success => result.GetValue() is null ? Results.NoContent() : Results.Ok(result.GetValue()),
        OutcomeType.Failure => BadRequest(result),
        OutcomeType.NotFound => NotFound(result),
        OutcomeType.Invalid => Invalid(result),
        _ => throw new Exception("")
    };

    private static IResult BadRequest(OutcomeBase outcome) => Results.BadRequest(new ProblemDetails
    {
        Title = "Bad Request",
        Detail = string.Join(',', outcome.Errors)
    });

    private static IResult NotFound(OutcomeBase outcome) => Results.NotFound(new ProblemDetails
    {
        Title = "Not Found",
        Detail = string.Join(',', outcome.Errors)
    });

    private static IResult Invalid(OutcomeBase outcome)
    {
        var validations = outcome.ValidationErrors
            .GroupBy(g => g.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.ErrorMessage).ToArray()
                );

        return Results.ValidationProblem(validations);
    }
}
