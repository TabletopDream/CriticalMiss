using System;
using System.Net.Http;

namespace CriticalMiss.UI.Exceptions
{
    public class HttpServiceException : Exception
    {
        public HttpResponseMessage HttpResponse { get; set; }
    }
}
