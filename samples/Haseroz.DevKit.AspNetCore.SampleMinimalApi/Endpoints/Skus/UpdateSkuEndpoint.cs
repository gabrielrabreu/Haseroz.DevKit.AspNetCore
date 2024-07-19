using Haseroz.DevKit.AspNetCore.SampleMinimalApi.DTOs;
using Haseroz.DevKit.AspNetCore.SampleMinimalApi.Models;
using Haseroz.DevKit.AspNetCore.SampleMinimalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints.Skus;

public class UpdateSkuEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPut("/Skus/{skuId}", Handle)
            .WithOpenApi()
            .WithTags("Skus")
            .ProducesOk<Sku>()
            .ProducesDefaultErrorResponses();
    }

    private IResult Handle([FromBody] UpdateSkuRequest request, int skuId, SkuService skuService)
    {
        return skuService.Update(skuId, request.Code).ToMinimalApiResult();
    }
}
