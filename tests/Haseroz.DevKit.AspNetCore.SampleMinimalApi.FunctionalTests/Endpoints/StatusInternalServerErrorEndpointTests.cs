using FluentAssertions;
using Haseroz.TestKit.FluentAssertions.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.FunctionalTests.Endpoints;

public class StatusInternalServerErrorEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/InternalServerError";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsInternalServerError()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().BeInternalServerError();
    }
}
