using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace KestrelWebsockets
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var websocketServer = new WebSocketConnection();
            websocketServer.Start(connection =>
            {
                connection.OnOpen = socket => Console.WriteLine("OnOpen");
                connection.OnClose = socket => Console.WriteLine("OnClose");
                connection.OnMessage = async (socket, message) =>
                {
                    Console.WriteLine($"OnMessage {message}");
                    await connection.SendAsync(socket, $"Echo: {message}");
                };
                connection.OnBinary = (socket, bytes) => Console.WriteLine($"OnBinary {Encoding.UTF8.GetString(bytes)}");
            });

            app.UseWebSockets();
            app.UseMiddleware<WebSocketManagerMiddleware>(websocketServer);
        }
    }
}
