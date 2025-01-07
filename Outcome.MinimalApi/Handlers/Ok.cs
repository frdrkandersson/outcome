using MediatR;
using Outcome.MinimalApi.Dtos;

namespace Outcome.MinimalApi.Handlers;

public record Ok() : IRequest<Outcome<Dummy>>;

public class OkHandler : IRequestHandler<Ok, Outcome<Dummy>>
{
    public async Task<Outcome<Dummy>> Handle(Ok request, CancellationToken cancellationToken)
    {
        Outcome<Dummy> dto = new Dummy("TestString", 999, true);

        await Task.CompletedTask; // Dummy

        return dto;
    }
}