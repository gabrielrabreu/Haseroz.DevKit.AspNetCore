using FluentAssertions;
using Haseroz.TestKit.FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.FunctionalTests.Endpoints;

public class StatusNoContentEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/NoContent";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsNoContent()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().BeNoContent();
    }
}
