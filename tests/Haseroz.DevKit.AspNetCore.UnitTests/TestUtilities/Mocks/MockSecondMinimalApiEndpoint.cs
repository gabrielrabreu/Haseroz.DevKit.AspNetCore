using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Haseroz.DevKit.AspNetCore.UnitTests.TestUtilities.Mocks;

public class MockSecondMinimalApiEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
    }
}
