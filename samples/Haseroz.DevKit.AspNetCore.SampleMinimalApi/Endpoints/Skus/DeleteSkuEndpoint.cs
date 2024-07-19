using Haseroz.DevKit.AspNetCore.SampleMinimalApi.Services;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints.Skus;

public class DeleteSkuEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapDelete("/Skus/{skuId}", Handle)
            .WithOpenApi()
            .WithTags("Skus")
            .ProducesNoContent()
            .ProducesDefaultErrorResponses();
    }

    private IResult Handle(int skuId, SkuService skuService)
    {
        return skuService.Delete(skuId).ToMinimalApiResult();
    }
}
