using MediatR;

namespace Outcome.MinimalApi.Handlers;

public record Ok() : IRequest<Outcome<object>>;

public class OkHandler : IRequestHandler<Ok, Outcome<object>>
{
    public async Task<Outcome<object>> Handle(Ok request, CancellationToken cancellationToken)
    {
        Outcome<object> dto = new { Ping = "Pong" };

        await Task.CompletedTask; // Dummy

        return dto;
    }
}