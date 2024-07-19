using Haseroz.DevKit.AspNetCore.SampleMinimalApi.DTOs;
using Haseroz.DevKit.AspNetCore.SampleMinimalApi.Models;
using Haseroz.DevKit.AspNetCore.SampleMinimalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints.Skus;

public class CreateSkuEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Skus", Handle)
            .WithOpenApi()
            .WithTags("Skus")
            .ProducesCreated<Sku>()
            .ProducesDefaultErrorResponses();
    }

    private IResult Handle([FromBody] CreateSkuRequest request, SkuService skuService)
    {
        return skuService.Create(request.Code).ToMinimalApiResult();
    }
}
