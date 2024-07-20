using Ardalis.Result;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints;

public class StatusNotFoundEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Status/NotFound", Handle)
            .WithOpenApi()
            .WithTags("Status")
            .ProducesNotFound();
    }

    private Microsoft.AspNetCore.Http.IResult Handle()
    {
        var result = Result.NotFound();
        return result.ToMinimalApiResult();
    }
}


