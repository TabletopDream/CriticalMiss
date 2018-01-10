using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Extensions
{
    /// <summary>
    /// Interface defining classes that determine metadata registration state
    /// for dependendy injection. Taken from:
    /// http://www.dotnet-programming.com/post/2017/05/08/Aspnet-core-Deserializing-Json-with-Dependency-Injection.aspx
    /// </summary>
    public interface IDIMeta
    {
        bool IsRegistered (Type t);
        Type RegisteredTypeFor (Type t);
    }
}
