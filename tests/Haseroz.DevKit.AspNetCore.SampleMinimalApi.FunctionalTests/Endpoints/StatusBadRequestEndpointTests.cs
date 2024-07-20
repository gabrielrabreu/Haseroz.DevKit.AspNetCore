using FluentAssertions;
using Haseroz.TestKit.FluentAssertions.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.FunctionalTests.Endpoints;

public class StatusBadRequestEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/BadRequest";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsBadRequest()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().BeBadRequest();
    }
}
