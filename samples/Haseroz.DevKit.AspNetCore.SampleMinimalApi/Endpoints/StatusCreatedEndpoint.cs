﻿using Ardalis.Result;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints;

public class StatusCreatedEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Status/Created", Handle)
            .WithOpenApi()
            .WithTags("Status")
            .ProducesCreated<string>();
    }

    private Microsoft.AspNetCore.Http.IResult Handle()
    {
        var result = Result<string>.Created("MyValue", "MyLocation");
        return result.ToMinimalApiResult();
    }
}


