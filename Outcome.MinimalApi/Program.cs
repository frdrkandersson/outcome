using MediatR;
using Microsoft.AspNetCore.Mvc;
using Outcome.MinimalApi;
using Outcome.MinimalApi.Handlers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(opts
    => opts.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

var routes = app.MapGroup("");

routes.AddEndpointFilter(new OutcomeEndpointFilter());

routes.MapGet("/Ok", ([FromServices] ISender mediatr) => mediatr.Send(new Ok()));

routes.MapGet("/NoContent", ([FromServices] ISender mediatr) => mediatr.Send(new NoContent()));

routes.MapGet("/Failure", ([FromServices] ISender mediatr) => mediatr.Send(new Failure()));

app.Run();