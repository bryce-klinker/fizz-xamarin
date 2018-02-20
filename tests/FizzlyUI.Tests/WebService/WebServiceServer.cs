using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FizzlyUI.Tests.WebService
{
    public class WebServiceServer : IDisposable
    {
        private readonly CancellationTokenSource _cancelSource;
        private readonly IWebHost _host;
        private readonly ValueService _valueService;

		private Task _serverTask;

        public WebServiceServer()
        {
            _cancelSource = new CancellationTokenSource();
            _host = WebHost.CreateDefaultBuilder()
                           .UseStartup<Startup>()
                           .Build();
            _valueService = _host.Services.GetService<ValueService>();
        }

        public void SetValue(int value) {
            _valueService.Value = value;
        }

        public void Start() {
            _serverTask = _host.StartAsync(_cancelSource.Token);
        }

        public void Stop() {
            Dispose();
        }

        public void Dispose()
        {
            _cancelSource.Cancel();
            _serverTask?.Wait();
        }
    }
}
