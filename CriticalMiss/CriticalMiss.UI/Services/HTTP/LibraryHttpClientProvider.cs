using CriticalMiss.UI.Services.HTTP.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Services.HTTP
{
    public class LibraryHttpClientProvider : ILibraryHttpClientProvider
    {
        private HttpClient _httpClient;

        public HttpClient LibraryConnection
        {
            get => _httpClient;
        }

        public LibraryHttpClientProvider(IOptions<HttpServicesConfiguration> config)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(config.Value.LibraryBaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose (bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                    _httpClient = null;
                }

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~LibraryHttpClientProvider() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose ()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
