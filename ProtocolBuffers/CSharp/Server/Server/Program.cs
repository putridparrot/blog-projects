using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PutridParrot.Music;
using Google.Protobuf;
using Grpc.Core;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Grpc.Core.Server
            {
                Services = {MusicService.BindService(new MusicServer())},
                Ports = {new ServerPort("127.0.0.1", 50051, ServerCredentials.Insecure)}
            };

            server.Start();

            Console.WriteLine("Press any key to stop the server");
            Console.ReadKey();
            server.ShutdownAsync().Wait();
        }
    }
}
