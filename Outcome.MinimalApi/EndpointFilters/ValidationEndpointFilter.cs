using FluentValidation;
using Outcome.MinimalApi.Extensions;

namespace Outcome.MinimalApi.EndpointFilters;

public class ValidationEndpointFilter(IServiceProvider serviceProvider) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        foreach (var arg in context.Arguments)
        {
            if (arg is null)
                continue;

            var validatorGenericType = typeof(IValidator<>).MakeGenericType(arg.GetType());

            if (serviceProvider.GetService(validatorGenericType) is not IValidator validator)
                continue;

            var contextGenericType = typeof(ValidationContext<>).MakeGenericType(arg.GetType());
            var validationContext = Activator.CreateInstance(contextGenericType, arg) as IValidationContext;

            var results = await validator.ValidateAsync(validationContext, context.HttpContext.RequestAborted);

            if (!results.IsValid)
                return Outcome.Invalid(results.Errors.AsErrors());
        }

        return await next(context);
    }
}
