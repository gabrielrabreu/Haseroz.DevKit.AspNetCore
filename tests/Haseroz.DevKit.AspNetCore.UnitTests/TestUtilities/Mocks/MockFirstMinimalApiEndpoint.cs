using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Haseroz.DevKit.AspNetCore.UnitTests.TestUtilities.Mocks;

public class MockFirstMinimalApiEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
    }
}
