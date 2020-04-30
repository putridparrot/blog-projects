using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebsocketClientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var websocketClient = new ClientWebSocket();
            var cancellationToken = new CancellationTokenSource();

            var connection = websocketClient.ConnectAsync(new Uri("ws://127.0.0.1:8181"), cancellationToken.Token);
            connection.ContinueWith(async tsk =>
            {
                // sends a string/text message causes OnMessage to be called
                await websocketClient.SendAsync(
                    new ArraySegment<byte>(Encoding.UTF8.GetBytes("Hello World")),
                    WebSocketMessageType.Text,
                    true,
                    cancellationToken.Token);

                var buffer = new byte[128];
                await websocketClient.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken.Token);
                Console.WriteLine(Encoding.UTF8.GetString(buffer));

                // sends a string/text message causes OnBinary to be called
                await websocketClient.SendAsync(
                    new ArraySegment<byte>(Encoding.UTF8.GetBytes("Hello World")),
                    WebSocketMessageType.Binary,
                    true,
                    cancellationToken.Token);
            });

            Console.WriteLine("Press <enter> to exit");
            Console.Read();

            // close the connection nicely
            websocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, "Bye", cancellationToken.Token);

            // this will cause OnError on the server if not closed first
            cancellationToken.Cancel();
        }
    }
}
