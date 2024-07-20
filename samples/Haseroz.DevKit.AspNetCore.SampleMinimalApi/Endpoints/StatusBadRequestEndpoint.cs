using Ardalis.Result;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints;

public class StatusBadRequestEndpoint : MinimalApiEndpoint
    {
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Status/BadRequest", Handle)
            .WithOpenApi()
            .WithTags("Status")
            .ProducesBadRequest();
    }

    private Microsoft.AspNetCore.Http.IResult Handle()
    {
        var result = Result.Invalid();
        return result.ToMinimalApiResult();
    }
}
