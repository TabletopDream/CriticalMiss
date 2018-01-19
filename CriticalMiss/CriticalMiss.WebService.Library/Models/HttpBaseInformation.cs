using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CriticalMiss.WebService.Library.Models
{
    public class HttpBaseInformation
    {
        public HttpClient Client { get; set; }

        public HttpBaseInformation()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:10112");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
