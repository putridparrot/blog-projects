using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KestrelTest
{
    public class Startup
    {
        public void Configure(IApplicationBuilder applicationBuilder,
            IHostingEnvironment hostingEnvironment)
        {
            //applicationBuilder.Run(async context =>
            //{
            //    // http://localhost:5000/
            //    await context.Response.WriteAsync("***Hello World***");
            //});

            // http://localhost:5000/hello/putridparrot
            //applicationBuilder.Map("/hello", app =>
            //{
            //    app.Run(async ctx =>
            //    {
            //        var request =
            //            ctx.Request.Path.HasValue ?
            //                ctx.Request.Path.Value.Substring(1) :
            //                String.Empty;
            //        await ctx.Response.WriteAsync("Hello " + request);
            //    });
            //});

            //  http://localhost:5000/hello?name=World
            applicationBuilder.Map("/hello", app =>
            {
                app.Run(async ctx =>
                {
                    await ctx.Response.WriteAsync(
                        "Hello " + ctx.Request.Query["name"]);
                });
            });

            applicationBuilder.Map("/error", app =>
            {
                app.Run(ctx =>
                    Task.FromResult(
                        ctx.Response.StatusCode = 404)
                );
            });

            // http://localhost:5000/index.html
            applicationBuilder.UseStaticFiles();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseKestrel()
                .Build()
                .Run();
        }
    }
}
