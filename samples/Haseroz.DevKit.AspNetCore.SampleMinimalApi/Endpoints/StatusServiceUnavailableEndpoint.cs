using Ardalis.Result;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints;

public class StatusServiceUnavailableEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Status/ServiceUnavailable", Handle)
            .WithOpenApi()
            .WithTags("Status")
            .ProducesServiceUnavailable();
    }

    private Microsoft.AspNetCore.Http.IResult Handle()
    {
        var result = Result.Unavailable();
        return result.ToMinimalApiResult();
    }
}


