using FluentAssertions;
using Haseroz.TestKit.FluentAssertions.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.FunctionalTests.Endpoints;

public class StatusServiceUnavailableEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/ServiceUnavailable";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsServiceUnavailable()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().BeServiceUnavailable();
    }
}