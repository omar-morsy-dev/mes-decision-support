
using System.Net;
using System.Net.Http.Json;
using MES.Application.Abstractions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MES.Api.Tests;

public sealed class HealthEndpointTests
{
    [Fact]
    public async Task Health_Returns200AndHealthy()
    {
        using var factory = new WebApplicationFactory<Program>();
        using var client = factory.CreateClient();

        using var response = await client.GetAsync("/health");
        var body = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("Healthy", body);
    }

    [Fact]
    public async Task Root_ReturnsApiInformation()
    {
        using var factory = new WebApplicationFactory<Program>();
        using var client = factory.CreateClient();

        using var response = await client.GetAsync("/");
        var result = await response.Content
            .ReadFromJsonAsync<ApiInformation>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(result);
        Assert.Equal("MES Decision Support API", result.Name);
        Assert.Equal("running", result.Status);
    }

    [Fact]
    public async Task SystemInfo_UsesInjectedClock()
    {
        var expectedTime = new DateTimeOffset(
            2026, 11, 11, 12, 0, 0, TimeSpan.Zero);

        using var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.RemoveAll<IClock>();
                    services.AddSingleton<IClock>(
                        new FakeClock(expectedTime));
                });
            });

        using var client = factory.CreateClient();

        using var response = await client.GetAsync(
            "/api/v1/system/info");

        var result = await response.Content
            .ReadFromJsonAsync<SystemInformation>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(result);
        Assert.Equal("MES Decision Support", result.Name);
        Assert.Equal(expectedTime, result.UtcTime);
        Assert.False(string.IsNullOrWhiteSpace(result.Version));
    }

    [Fact]
    public async Task UnknownRoute_Returns404()
    {
        using var factory = new WebApplicationFactory<Program>();
        using var client = factory.CreateClient();

        using var response = await client.GetAsync(
            "/api/v1/does-not-exist");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    private sealed record ApiInformation(
        string Name,
        string Status);

    private sealed record SystemInformation(
        string Name,
        DateTimeOffset UtcTime,
        string Version);

    private sealed class FakeClock(DateTimeOffset time) : IClock
    {
        public DateTimeOffset UtcNow => time;
    }
}
