using Ardalis.Result;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints;

public class StatusNoContentEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Status/NoContent", Handle)
            .WithOpenApi()
            .WithTags("Status")
            .ProducesNoContent();
    }

    private Microsoft.AspNetCore.Http.IResult Handle()
    {
        var result = Result.NoContent();
        return result.ToMinimalApiResult();
    }
}


