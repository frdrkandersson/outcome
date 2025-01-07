using Outcome.MinimalApi;
using Outcome.MinimalApi.EndpointFilters;
using Outcome.MinimalApi.FluentValidation;
using Scalar.AspNetCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureHttpJsonOptions(options => options
    .SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddOpenApi();

builder.Services.AddMediatR(options => options
    .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddFluentValidation();

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.MapOpenApi(); // Endpoint: /openapi or /openapi/v1.json

var routes = app.MapGroup("");

routes.AddEndpointFilter<OutcomeEndpointFilter>();
routes.AddEndpointFilter<ValidationEndpointFilter>();

routes.AddRoutes();

app.Run();