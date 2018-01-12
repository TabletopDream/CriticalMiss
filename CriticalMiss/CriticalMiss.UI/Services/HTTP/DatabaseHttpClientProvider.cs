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
    /// <summary>
    /// Database client provider.
    /// 
    /// Should change URI string to pull from IOptionsMonitor instead of IOptions:
    /// https://andrewlock.net/reloading-strongly-typed-options-in-asp-net-core-1-1-0/
    /// </summary>
    public class DatabaseHttpClientProvider : IDatabaseHttpClientProvider
    {
        private HttpClient _httpClient;

        HttpClient IDatabaseHttpClientProvider.DatabaseConnection
        {
            get => _httpClient;
        }

        public DatabaseHttpClientProvider(IOptions<HttpServicesConfiguration> options)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(options.Value.DbBaseUrl)
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
                    // TODO: dispose managed state (managed objects).
                    _httpClient.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DatabaseHttpClientProvider() {
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
