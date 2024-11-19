namespace Outcome;

public sealed class Outcome(OutcomeType type) : OutcomeBase(type)
{
    public static Outcome Success() => new(OutcomeType.Success);
    public static Outcome Failure() => new(OutcomeType.Failure);
}
