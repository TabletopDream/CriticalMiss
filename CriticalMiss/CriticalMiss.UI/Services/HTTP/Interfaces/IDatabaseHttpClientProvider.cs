using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Services.HTTP.Interfaces
{
    public interface IDatabaseHttpClientProvider : IDisposable
    {
        HttpClient DatabaseConnection { get; }
    }
}
