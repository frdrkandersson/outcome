using MediatR;
using Outcome.MinimalApi.Models;

namespace Outcome.MinimalApi.Handlers;

public record GetGenericOutcome(bool Success) : IRequest<Outcome<Dto>>;

public class GetGenericResultHandler : IRequestHandler<GetGenericOutcome, Outcome<Dto>>
{
    public Task<Outcome<Dto>> Handle(GetGenericOutcome request, CancellationToken cancellationToken)
    {
        Outcome<Dto> result = request.Success ? Outcome.Success() : Outcome.Failure();

        return Task.FromResult(result);
    }
}