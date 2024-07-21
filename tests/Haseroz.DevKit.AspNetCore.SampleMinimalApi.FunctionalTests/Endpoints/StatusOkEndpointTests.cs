using FluentAssertions;
using Haseroz.TestKit.FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.FunctionalTests.Endpoints;

public class StatusOkEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/Ok";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsOk()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().BeOk();

        var content = await response.Content.ReadAsStringAsync();
        content.Trim('\"').Should().Be("MyValue");
    }
}
