using Haseroz.DevKit.AspNetCore.SampleMinimalApi.Services;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Endpoints.Health;

public class MaintenanceEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/Health/Maintenance", Handle)
            .WithOpenApi()
            .WithTags("Health")
            .ProducesNoContent()
            .ProducesDefaultErrorResponses();
    }

    private IResult Handle(HealthService healthService)
    {
        return healthService.Maintenance().ToMinimalApiResult();
    }
}
