using Ardalis.Result;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints;

public class StatusOkEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Status/Ok", Handle)
            .WithOpenApi()
            .WithTags("Status")
            .Produces<Ok<string>>();
    }

    private Microsoft.AspNetCore.Http.IResult Handle()
    {
        var result = Result.Success("MyValue");
        return result.ToMinimalApiResult();
    }
}


