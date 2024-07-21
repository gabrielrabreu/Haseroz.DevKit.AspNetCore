using System.Reflection;

namespace Haseroz.DevKit.AspNetCore;

public class MinimalApiEndpointConfiguration
{
    private readonly List<Type> _types = [];

    public IEnumerable<Type> GetEndpoints() => _types;

    public void FromType<T>() where T : MinimalApiEndpoint
    {
        _types.Add(typeof(T));
    }

    public void FromAssembly(Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(MinimalApiEndpoint)) && !t.IsAbstract);

        _types.AddRange(types);
    }
}