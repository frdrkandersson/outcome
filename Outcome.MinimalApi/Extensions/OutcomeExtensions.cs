namespace Outcome.MinimalApi.Extensions;

public static class OutcomeExtensions
{
    public static IResult ToResult(this OutcomeBase result) => result.Type switch
    {
        OutcomeType.Success => result.GetValue() is null ? Results.NoContent() : Results.Ok(result.GetValue()),
        OutcomeType.Failure => Results.BadRequest(),
        _ => throw new Exception("")
    };
}
