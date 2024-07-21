using Ardalis.Result;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints;

public class StatusOkEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Status/Ok", Handle)
            .WithOpenApi()
            .WithTags("Status")
            .ProducesOk<string>();
    }

    private Microsoft.AspNetCore.Http.IResult Handle()
    {
        var result = Result.Success("MyValue");
        return result.ToMinimalApiResult();
    }
}


