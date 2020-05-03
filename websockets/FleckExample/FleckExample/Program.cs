using System;
using System.Diagnostics;
using System.Text;
using Fleck;

namespace FleckExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var websocketServer = new WebSocketServer("ws://0.0.0.0:8181");
            websocketServer.Start(connection =>
            {
                connection.OnOpen = () =>
                {
                    Console.WriteLine("OnOpen");
                    Console.WriteLine(connection.ConnectionInfo.Id);
                    Console.WriteLine(connection.ConnectionInfo.Path);
                };
                connection.OnClose = () => Console.WriteLine("OnClose");
                connection.OnMessage = message =>
                {
                    Console.WriteLine($"OnMessage {message}");
                    connection.Send($"Echo: {message}");
                };
                connection.OnBinary = bytes => Console.WriteLine($"OnBinary {Encoding.UTF8.GetString(bytes)}");
                connection.OnError = exception => Console.WriteLine($"OnError {exception.Message}");
                connection.OnPing = bytes => Console.WriteLine("OnPing");
                connection.OnPong = bytes => Console.WriteLine("OnPong");
            });

            Console.WriteLine("Press <enter> to exit");
            Console.Read();

            websocketServer.Dispose();
        }
    }
}
