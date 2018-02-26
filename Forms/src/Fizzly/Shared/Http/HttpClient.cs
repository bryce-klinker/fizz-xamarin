using System.Net.Http;
using System.Threading.Tasks;

namespace Fizzly.Shared.Http
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }

    class HttpClient : IHttpClient
    {
        private readonly System.Net.Http.HttpClient _client;

        public HttpClient()
        {
            _client = new System.Net.Http.HttpClient();
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return _client.GetAsync(url);
        }
    }
}
