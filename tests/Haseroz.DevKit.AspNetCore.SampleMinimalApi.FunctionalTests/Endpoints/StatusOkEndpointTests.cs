using FluentAssertions;
using Haseroz.TestKit.FluentAssertions.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.FunctionalTests.Endpoints;

public class StatusOkEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/OK";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsOK()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().BeOK();

        var content = await response.Content.ReadAsStringAsync();
        content.Trim('\"').Should().Be("MyValue");
    }
}
