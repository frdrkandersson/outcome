namespace Outcome;

public sealed class Outcome<TValue> : OutcomeBase
{
    private readonly TValue? _value;

    private Outcome() : base(OutcomeType.Success) { }

    public Outcome(TValue value) : this() => _value = value;

    public TValue Value
    {
        get
        {
            if (!IsSuccess || _value is null)
            {
                throw new InvalidOperationException($"The {nameof(Value)} property cannot be accessed. Check {nameof(IsSuccess)} before accessing {nameof(Value)}.");
            }

            return _value;
        }
    }

    public override object? GetValue() => _value;

    public static implicit operator Outcome<TValue>(TValue value) => new(value);

    public static implicit operator Outcome<TValue>(Outcome _) => new();
}