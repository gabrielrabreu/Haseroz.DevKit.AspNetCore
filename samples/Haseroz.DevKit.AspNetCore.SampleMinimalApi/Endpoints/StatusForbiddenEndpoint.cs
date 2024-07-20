using Ardalis.Result;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints;

public class StatusForbiddenEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Status/Forbidden", Handle)
            .WithOpenApi()
            .WithTags("Status")
            .ProducesForbidden();
    }

    private Microsoft.AspNetCore.Http.IResult Handle()
    {
        var result = Result.Forbidden();
        return result.ToMinimalApiResult();
    }
}


