using FluentValidation;
using MediatR;
using Outcome.MinimalApi.Dtos;

namespace Outcome.MinimalApi.Handlers;

public record Validate(Dummy Dummy) : IRequest<Outcome>;

public class ValidateHandler : IRequestHandler<Validate, Outcome>
{
    public Task<Outcome> Handle(Validate request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Outcome.Success()); // The pipeline behavior should run the validation
    }
}

public class ValidateValidator : AbstractValidator<Validate>
{
    public ValidateValidator()
    {
        RuleFor(x => x.Dummy).SetValidator(new DummyValidator());
    }
}