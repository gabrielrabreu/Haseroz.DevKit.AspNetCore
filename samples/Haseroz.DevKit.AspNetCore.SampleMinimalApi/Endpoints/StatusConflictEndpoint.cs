using Ardalis.Result;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints;

public class StatusConflictEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Status/Conflict", Handle)
            .WithOpenApi()
            .WithTags("Status")
            .ProducesConflict();
    }

    private Microsoft.AspNetCore.Http.IResult Handle()
    {
        var result = Result.Conflict();
        return result.ToMinimalApiResult();
    }
}


