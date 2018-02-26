using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Fizzly.Shared;
using Newtonsoft.Json;

namespace Fizzly.Tests.Fakes
{
    public class FakeHttpClient : IHttpClient
    {
        private readonly Dictionary<string, object> _results;

        public FakeHttpClient()
        {
            _results = new Dictionary<string, object>();
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            if (!_results.TryGetValue(url, out object result))
                return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.NotFound));

            var json = JsonConvert.SerializeObject(result);
            var content = new StringContent(json)
            {
                Headers =
                {
                    ContentType = MediaTypeHeaderValue.Parse("application/json")
                }
            };
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = content
            };
            return Task.FromResult(response);
        }

        public void SetupGet<T>(string url, T result)
        {
            _results.Add(url, result);
        }
    }
}
