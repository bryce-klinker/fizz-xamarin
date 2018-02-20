using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace FizzlyUI.Tests.WebService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ValueService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                var valueService = context.RequestServices.GetService<ValueService>();
                var json = JsonConvert.SerializeObject(valueService.Value);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 200;
                return context.Response.WriteAsync(json);
            });
        }
    }
}
