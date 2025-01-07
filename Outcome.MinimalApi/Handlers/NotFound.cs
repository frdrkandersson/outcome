using MediatR;

namespace Outcome.MinimalApi.Handlers;

public record NotFound() : IRequest<Outcome>;

public class NotFoundHandler : IRequestHandler<NoContent, Outcome>
{
    public Task<Outcome> Handle(NoContent request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Outcome.NotFound());
    }
}