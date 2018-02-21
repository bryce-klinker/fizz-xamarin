using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fizzly.Shared
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}
