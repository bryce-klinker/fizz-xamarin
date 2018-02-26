using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Routing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace FakeWebService
{
    public class Program
    {
        public static int Value { get; set; }

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args)
            .CaptureStartupErrors(true)
            .ConfigureServices(services =>
            {
                services.AddRouting();
            })
            .Configure(app => app.UseRouter(GetRoutes(app)))
            .Build();

        public static IRouter GetRoutes(IApplicationBuilder app) => 
            new RouteBuilder(app)
            .MapGet("", ctx => {
                var json = JsonConvert.SerializeObject(JObject.FromObject(new { Value }));
                return ctx.Response.WriteAsync(json);
            })
            .MapPost("", async ctx =>
            {
                var json = await ctx.ReadRequestBodyAsync();
                Value = JsonConvert.DeserializeObject<JObject>(json).Value<int>("Value");
                ctx.Response.StatusCode = (int) HttpStatusCode.NoContent;
            })
            .Build();
    }

    public static class HttpContextExtensions {
        public static async Task<string> ReadRequestBodyAsync(this HttpContext context) {
            using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8)) {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
