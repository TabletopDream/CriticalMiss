using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Extensions
{
    /// <summary>
    /// Options setup class. Enables the setup of dependency injection for
    /// instantiation of models being returned by the user.
    /// 
    /// Sourced from:
    /// http://www.dotnet-programming.com/post/2017/05/08/Aspnet-core-Deserializing-Json-with-Dependency-Injection.aspx
    /// </summary>
    public class JsonOptionsSetup : IConfigureOptions<MvcJsonOptions>
    {
        IServiceProvider serviceProvider;
        public JsonOptionsSetup (IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public void Configure (MvcJsonOptions o)
        {
            o.SerializerSettings.ContractResolver =
                new DIContractResolver(serviceProvider.GetService(typeof(IDIMeta)) as IDIMeta, serviceProvider);
        }
    }
}
