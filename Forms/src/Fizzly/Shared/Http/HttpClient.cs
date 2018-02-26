using System.Net.Http;
using System.Threading.Tasks;

namespace Fizzly.Shared.Http
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}
