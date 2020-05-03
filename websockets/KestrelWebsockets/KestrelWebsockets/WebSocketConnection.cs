using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KestrelWebsockets
{
    public class WebSocketConnection
    {
        public void Start(Action<WebSocketConnection> connection)
        {
            connection(this);
        }

        public Action<WebSocket> OnOpen { get; set; } = webSocket => { };
        public Action<WebSocket> OnClose { get; set; } = webSocket => { };
        public Action<WebSocket, string> OnMessage { get; set; } = (webSocket, message) => { };
        public Action<WebSocket, byte[]> OnBinary { get; set; } = (webSocket, bytes) => { };

        public async Task SendAsync(WebSocket socket, string message)
        {
            if (socket.State == WebSocketState.Open)
            {
                await socket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(message),
                        0,
                        message.Length),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None);
            }
        }
    }
}
