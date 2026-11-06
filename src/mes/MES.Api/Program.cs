
using MES.Application.Abstractions;
using MES.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapGet("/", () =>
    Results.Ok(new
    {
        name = "MES Decision Support API",
        status = "running"
    }));

app.MapGet("/api/v1/system/info", (IClock clock) =>
    Results.Ok(new
    {
        name = "MES Decision Support",
        utcTime = clock.UtcNow,
        version = "0.1.0"
    }));

app.MapHealthChecks("/health");

app.Run();

public partial class Program { }
