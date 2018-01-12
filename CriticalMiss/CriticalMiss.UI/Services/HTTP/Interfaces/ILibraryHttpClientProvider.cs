using System;
using System.Net.Http;

namespace CriticalMiss.UI.Services.HTTP.Interfaces
{
    public interface ILibraryHttpClientProvider : IDisposable
    {
        HttpClient LibraryConnection { get; }
    }
}
