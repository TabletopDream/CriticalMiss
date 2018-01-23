using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Extensions
{
    /// <summary>
    /// Default implementation for the IDIMeta type.
    /// 
    /// Taken from
    /// http://www.dotnet-programming.com/post/2017/05/08/Aspnet-core-Deserializing-Json-with-Dependency-Injection.aspx
    /// </summary>
    public class DIMetaDefault : IDIMeta
    {
        private IDictionary<Type, Type> _registrar = new Dictionary<Type, Type>();

        public DIMetaDefault(IServiceCollection services)
        {
            foreach (var service in services)
            {
                _registrar[service.ServiceType] = service.ImplementationType;
            }
        }

        bool IDIMeta.IsRegistered (Type t)
        {
            return _registrar.ContainsKey(t);
        }

        Type IDIMeta.RegisteredTypeFor (Type t)
        {
            return _registrar[t];
        }
    }
}
