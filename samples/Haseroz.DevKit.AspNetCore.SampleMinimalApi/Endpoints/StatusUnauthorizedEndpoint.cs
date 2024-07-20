using Ardalis.Result;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints;

public class StatusUnauthorizedEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Status/Unauthorized", Handle)
            .WithOpenApi()
            .WithTags("Status")
            .ProducesUnauthorized();
    }

    private Microsoft.AspNetCore.Http.IResult Handle()
    {
        var result = Result.Unauthorized();
        return result.ToMinimalApiResult();
    }
}


