using FluentValidation;
using MediatR;
using Outcome.MinimalApi.Dtos;
using Outcome.MinimalApi.Extensions;

namespace Outcome.MinimalApi.Handlers;

public enum ExampleResult
{
    Success,
    NotFound,
    BadRequest,
    Invalid,
    Exception
}

public record FullExample(ExampleResult Result) : IRequest<Outcome<Dummy>>;

public class FullExampleHandler(IValidator<Dummy> validator) : IRequestHandler<FullExample, Outcome<Dummy>>
{
    public async Task<Outcome<Dummy>> Handle(FullExample request, CancellationToken cancellationToken)
    {
        if (request.Result == ExampleResult.NotFound) return Outcome.NotFound("not found error message");
        if (request.Result == ExampleResult.BadRequest) return Outcome.Failure("error message");
        if (request.Result == ExampleResult.Exception) throw new Exception();

        if (request.Result == ExampleResult.Invalid)
        {
            var invalidDummy = new Dummy("12345678910", -10, false);

            var result = validator.Validate(invalidDummy);

            if (!result.IsValid)
            {
                return Outcome.Invalid(result.Errors.AsErrors());
            }
        }

        var outcome = new Dummy("TestString", 999, true);

        await Task.CompletedTask; // This is just to create a task too see that working

        return outcome;
    }
}