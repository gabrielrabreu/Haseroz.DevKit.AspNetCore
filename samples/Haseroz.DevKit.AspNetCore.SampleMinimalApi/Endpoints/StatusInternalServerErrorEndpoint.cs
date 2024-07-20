﻿using Ardalis.Result;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints;

public class StatusInternalServerErrorEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Status/InternalServerError", Handle)
            .WithOpenApi()
            .WithTags("Status")
            .ProducesInternalServerError();
    }

    private Microsoft.AspNetCore.Http.IResult Handle()
    {
        var result = Result.CriticalError();
        return result.ToMinimalApiResult();
    }
}

