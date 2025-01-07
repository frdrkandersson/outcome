using FluentValidation;

namespace Outcome.MinimalApi.Dtos;

public record Dummy(string StringValue, int IntValue, bool BoolValue);

public class DummyValidator : AbstractValidator<Dummy>
{
    public DummyValidator()
    {
        RuleFor(x => x.BoolValue).NotNull();

        RuleFor(x => x.IntValue)
            .NotNull()
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.StringValue)
            .NotNull()
            .MinimumLength(1)
            .MaximumLength(10)
            .NotEqual("12345678910");
    }
}