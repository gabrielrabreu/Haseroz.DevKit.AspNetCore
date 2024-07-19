using Haseroz.DevKit.AspNetCore;
using Microsoft.AspNetCore.Routing;
using System.Reflection;

namespace Haseroz.DevKit.MinimalApis;

public static partial class MinimalApiEndpointExtensions
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder builder, Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(MinimalApiEndpoint)) && !t.IsAbstract);

        foreach (Type type in types)
            if (Activator.CreateInstance(type) is MinimalApiEndpoint minimalEndpoint)
                minimalEndpoint.Define(builder);
    }

    public static void RegisterEndpoints(this IEndpointRouteBuilder builder, Action<MinimalApiEndpointConfiguration> configure)
    {
        var configuration = new MinimalApiEndpointConfiguration();

        configure(configuration);

        foreach (var type in configuration.GetEndpoints())
        {
            if (Activator.CreateInstance(type) is MinimalApiEndpoint endpointInstance)
            {
                endpointInstance.Define(builder);
            }
        }
    }
}
