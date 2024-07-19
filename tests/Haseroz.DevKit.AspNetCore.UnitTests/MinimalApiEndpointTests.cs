using Microsoft.AspNetCore.Routing;
using NSubstitute;

namespace Haseroz.DevKit.AspNetCore.UnitTests;

public class MinimalApiEndpointTests
{
    [Fact]
    public void Teste()
    {
        var endpoint = new ConcreteMinimalApiEndpoint();

        var builder = Substitute.For<IEndpointRouteBuilder>();
        endpoint.Define(builder);
        Assert.True(true);
    }
}


public class ConcreteMinimalApiEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
    }
}