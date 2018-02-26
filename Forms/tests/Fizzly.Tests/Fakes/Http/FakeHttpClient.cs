using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Fizzly.Shared.Http;
using Newtonsoft.Json;

namespace Fizzly.Tests.Fakes.Http
{
    public class FakeHttpClient : IHttpClient
    {
        public static readonly HttpResponseMessage DefaultResponse = new HttpResponseMessage(HttpStatusCode.OK);
        private readonly Dictionary<string, HttpResponseMessage> _responses;

        public FakeHttpClient()
        {
            _responses = new Dictionary<string, HttpResponseMessage>();
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            var response = _responses.ContainsKey(url)
                ? _responses[url]
                : DefaultResponse;
            return Task.FromResult(response);
        }

        public void SetupJsonResponse<T>(string url, T body)
        {
            var json = JsonConvert.SerializeObject(body);
            SetupResponse(url, json);
        }

        public void SetupResponse(string url, string body, string mediaType = "application/json")
        {
            var content = new StringContent(body, Encoding.UTF8, mediaType);
            var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = content};
            SetupResponse(url, response);
        }

        public void SetupResponse(string url, HttpResponseMessage response)
        {
            _responses.Add(url, response);
        }
    }
}
