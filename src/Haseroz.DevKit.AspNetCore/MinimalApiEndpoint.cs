using Microsoft.AspNetCore.Routing;

namespace Haseroz.DevKit.AspNetCore;

public abstract class MinimalApiEndpoint
{
    public abstract void Define(IEndpointRouteBuilder builder);
}
