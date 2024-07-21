using FluentAssertions;
using Haseroz.TestKit.FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.FunctionalTests.Endpoints;

public class StatusCreatedEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/Created";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsCreated()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().BeCreated();
        response.Headers.Should().HaveLocation("MyLocation");

        var content = await response.Content.ReadAsStringAsync();
        content.Trim('\"').Should().Be("MyValue");
    }
}
