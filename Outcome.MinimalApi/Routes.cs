﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Outcome.MinimalApi.Dtos;
using Outcome.MinimalApi.Extensions;
using Outcome.MinimalApi.Handlers;

namespace Outcome.MinimalApi;

public static class Routes
{
    public static void AddRoutes(this RouteGroupBuilder app)
    {
        var group = app.MapGroup("").WithTags("Outcome");

        group.MapGet("/Ok", Ok)
            .Produces(200, typeof(Dummy));

        group.MapGet("/NoContent", NoContent)
            .Produces(204);

        group.MapGet("/Failure", Failure)
            .Produces(400);

        group.MapPost("/Validate", Validate)
            .Produces(200)
            .Produces(400);

        group.MapGet("/Full-Example", FullExample)
            .Produces(200, typeof(Dummy))
            .Produces(400)
            .Produces(404)
            .Produces(500);
    }

    private static async Task<IResult> Ok(ISender mediator)
    {
        var outcome = await mediator.Send(new Ok());
        return outcome.ToResult();
    }

    private static async Task<IResult> NoContent(ISender mediator)
    {
        var outcome = await mediator.Send(new NoContent());
        return outcome.ToResult();
    }

    private static async Task<IResult> Failure(ISender mediator)
    {
        var outcome = await mediator.Send(new Failure());
        return outcome.ToResult();
    }

    private static async Task<IResult> Validate(ISender mediator, [FromBody] Dummy dummy)
    {
        var outcome = await mediator.Send(new Validate(dummy));
        return outcome.ToResult();
    }

    private static Task<Outcome<Dummy>> FullExample(ISender mediator, ExampleResult result) => mediator.Send(new FullExample(result));
}