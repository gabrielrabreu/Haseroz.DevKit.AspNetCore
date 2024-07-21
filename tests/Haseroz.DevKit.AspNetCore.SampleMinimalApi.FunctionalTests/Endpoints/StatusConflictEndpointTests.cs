using FluentAssertions;
using Haseroz.TestKit.FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.FunctionalTests.Endpoints;

public class StatusConflictEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/Conflict";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsConflict()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().BeConflict();
    }
}
