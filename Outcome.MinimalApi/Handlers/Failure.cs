using MediatR;

namespace Outcome.MinimalApi.Handlers;

public record Failure() : IRequest<Outcome>;

public class FailureHandler : IRequestHandler<Failure, Outcome>
{
    public Task<Outcome> Handle(Failure request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Outcome.Failure());
    }
}