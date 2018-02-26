using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO;
using System.Net.Http;

namespace Fizzly.UITests.WebService
{
    public class WebServiceServer : IDisposable
    {
        private Process _process;

        public async Task Start()
        {
            _process = StartMainProcess();
            await WaitForApiToBeReady();
        }

        public async Task SetValue(int value) 
        {
            using (var client = new HttpClient()) 
            {
                var json = JObject.FromObject(new { Value = value });
                var content = new StringContent(JsonConvert.SerializeObject(json));
                await client.PostAsync("http://localhost:5000", content);
            }
        }

        public void Dispose()
        {
            KillChildProcesses();

            if (!_process.HasExited)
                _process.Kill();

            _process.Dispose();
        }

        private void KillChildProcesses() 
        {
            var dotnetProcesses = Process.GetProcesses()
                                         .Where(p => p.Modules.Count > 0)
                                         .Where(p => p.MainModule.ModuleName.ToLowerInvariant().Contains("dotnet"))
                                         .ToList();
            foreach (var process in dotnetProcesses.Where(p => !p.HasExited))
            {
                process.Kill();
            }
        }

        private Process StartMainProcess() 
        {
            var webServicePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "FakeWebService");
            var fullPath = Path.GetFullPath(webServicePath);

            return Process.Start(new ProcessStartInfo
            {
                UseShellExecute = true,
                LoadUserProfile = true,
                FileName = "/bin/bash",
                Arguments = $"-c \"cd {fullPath} && dotnet run --port 5000\""
            });
        }

        private async Task WaitForApiToBeReady() 
        {
            for (int i = 0; i < 10; i++)
            {
                if (await IsServerReady())
                    return;
                
                await Task.Delay(2000);
            }

            throw new TimeoutException("Api failed to start.");
        }

        private async Task<bool> IsServerReady() 
        {
            try 
            {
                using (var client = new HttpClient()) 
                {
                    var response = await client.GetAsync("http://localhost:5000");
                    return response.IsSuccessStatusCode;
                }
            } 
            catch (Exception) 
            {
                return false;
            } 

        }
    }
}
