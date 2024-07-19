using Haseroz.DevKit.AspNetCore.SampleMinimalApi.Models;
using Haseroz.DevKit.AspNetCore.SampleMinimalApi.Services;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints.Skus;

public class GetSkuEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/Skus/{skuId}", Handle)
            .WithOpenApi()
            .WithTags("Skus")
            .ProducesOk<Sku>()
            .ProducesDefaultErrorResponses();
    }
    private IResult Handle(int skuId, SkuService skuService)
    {
        return skuService.Get(skuId).ToMinimalApiResult();
    }
}
