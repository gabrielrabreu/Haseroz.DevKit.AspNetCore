using Haseroz.DevKit.AspNetCore.SampleMinimalApi.Models;
using Haseroz.DevKit.AspNetCore.SampleMinimalApi.Services;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints.Skus;

public class ListSkusEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/Skus", Handle)
            .WithOpenApi()
            .WithTags("Skus")
            .ProducesOk<IReadOnlyCollection<Sku>>()
            .ProducesDefaultErrorResponses();
    }
    private IResult Handle(SkuService skuService)
    {
        return skuService.List().ToMinimalApiResult();
    }
}
