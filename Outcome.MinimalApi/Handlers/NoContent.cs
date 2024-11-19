using MediatR;

namespace Outcome.MinimalApi.Handlers;

public record NoContent() : IRequest<Outcome>;

public class NoContentHandler : IRequestHandler<NoContent, Outcome>
{
    public Task<Outcome> Handle(NoContent request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Outcome.Success());
    }
}