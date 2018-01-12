using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Services.HTTP
{
    public class HttpServicesConfiguration
    {
        public const string ConfigurationKey = "HttpServices";

        public string DbBaseUrl { get; set; }

        public string LibraryBaseUrl { get; set; }
    }
}
