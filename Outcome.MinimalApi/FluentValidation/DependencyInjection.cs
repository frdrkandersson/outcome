using FluentValidation;
using System.Reflection;

namespace Outcome.MinimalApi.FluentValidation;

public static class DependencyInjection
{
    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        ValidatorOptions.Global.PropertyNameResolver = CamelCasePropertyNameResolver.ResolvePropertyName;
        return services;
    }
}
