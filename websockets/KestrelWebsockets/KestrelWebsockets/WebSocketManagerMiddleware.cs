using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace KestrelWebsockets
{
    public class WebSocketManagerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebSocketConnection _connection;

        public WebSocketManagerMiddleware(RequestDelegate next, WebSocketConnection connection)
        {
            _next = next;
            _connection = connection;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {

                var socket = await context.WebSockets.AcceptWebSocketAsync();

                _connection.OnOpen(socket);

                await Receive(socket, (result, buffer) =>
                {
                    switch (result.MessageType)
                    {
                        case WebSocketMessageType.Text:
                            var s = Encoding.UTF8.GetString(buffer);
                            _connection.OnMessage(socket, s.Substring(0, Math.Max(0, s.IndexOf('\0'))));
                            break;
                        case WebSocketMessageType.Binary:
                            _connection.OnBinary(socket, buffer);
                            break;
                        case WebSocketMessageType.Close:
                            _connection.OnClose(socket);
                            break;
                    }
                });
            }

            await _next(context);
        }

        private async Task Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handler)
        {
            var buffer = new byte[1024];

            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(buffer: 
                    new ArraySegment<byte>(buffer),
                    cancellationToken: CancellationToken.None);

                handler(result, buffer);
            }
        }
    }
}
