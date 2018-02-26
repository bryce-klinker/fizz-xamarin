using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fizzly.Shared
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }

    public class HttpClient : IHttpClient
    {
        private readonly System.Net.Http.HttpClient _client;

        public HttpClient(string baseUrl = "http://localhost:5000")
        {
            _client = new System.Net.Http.HttpClient{ BaseAddress = new Uri(baseUrl) };
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return _client.GetAsync(url);
        }
    }
}
