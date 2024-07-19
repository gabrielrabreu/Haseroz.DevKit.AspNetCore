using Haseroz.DevKit.AspNetCore;

namespace Haseroz.DevKit.MinimalApis;

public static partial class MinimalApiEndpointExtensions
{
    public class MinimalApiEndpointConfiguration
    {
        private readonly List<Type> _types = [];

        public void AddEndpoint<T>() where T : MinimalApiEndpoint
        {
            _types.Add(typeof(T));
        }

        public IEnumerable<Type> GetEndpoints() => _types;
    }
}
