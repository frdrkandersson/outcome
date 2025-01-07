namespace Outcome;

public abstract class OutcomeBase(OutcomeType type)
{
    public OutcomeType Type { get; protected set; } = type;
    public bool IsSuccess => Type is OutcomeType.Success;
    public virtual object? GetValue() => null;
    public IEnumerable<string> Errors { get; protected set; } = [];
    public IEnumerable<ValidationError> ValidationErrors { get; protected set; } = [];
}
