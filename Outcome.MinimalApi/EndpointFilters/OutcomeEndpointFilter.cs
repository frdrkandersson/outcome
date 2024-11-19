using Outcome.MinimalApi.Extensions;

namespace Outcome.MinimalApi.EndpointFilters;

public class OutcomeEndpointFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var result = await next(context);

        return result is OutcomeBase outcome ? outcome.ToResult() : result;
    }
}
