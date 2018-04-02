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
            // http://localhost:5000/index.html
            applicationBuilder.UseStaticFiles();

            applicationBuilder.Run(async context =>
            {
                // http://localhost:5000/
                await context.Response.WriteAsync("***Hello World***");
            });
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
