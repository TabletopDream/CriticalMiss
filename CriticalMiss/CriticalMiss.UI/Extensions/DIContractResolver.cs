using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Extensions
{
    /// <summary>
    /// Contract resolver for the JSON model-dependency injector.
    /// 
    /// Taken from:
    /// http://www.dotnet-programming.com/post/2017/05/08/Aspnet-core-Deserializing-Json-with-Dependency-Injection.aspx
    /// </summary>
    public class DIContractResolver : CamelCasePropertyNamesContractResolver
    {
        private IDIMeta _diMeta;
        private IServiceProvider _sp;
        public DIContractResolver (IDIMeta diMeta, IServiceProvider sp)
        {
            _diMeta = diMeta;
            _sp = sp;
        }

        protected override JsonObjectContract CreateObjectContract (Type objectType)
        {

            if (_diMeta.IsRegistered(objectType))
            {
                JsonObjectContract contract = DIResolveContract(objectType);
                contract.DefaultCreator = () => _sp.GetService(objectType);

                return contract;
            }

            return base.CreateObjectContract(objectType);
        }

        private JsonObjectContract DIResolveContract (Type objectType)
        {
            var fType = _diMeta.RegisteredTypeFor(objectType);
            if (fType != null) return base.CreateObjectContract(fType);
            else return CreateObjectContract(objectType);
        }
    }
}
