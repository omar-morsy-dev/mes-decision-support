using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MES.Api.Tests;

public sealed class HealthEndpointTests
{
    [Fact]
    public async Task Health_Returns200AndHealthy()
    {
        using var factory =
            new WebApplicationFactory<Program>();

        using var client = factory.CreateClient();

        using var response =
            await client.GetAsync("/health");

        var body =
            await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("Healthy", body);
    }

    [Fact]
    public async Task SystemInfo_ReturnsSuccess()
    {
        using var factory =
            new WebApplicationFactory<Program>();

        using var client = factory.CreateClient();

        using var response =
            await client.GetAsync("/api/v1/system/info");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
