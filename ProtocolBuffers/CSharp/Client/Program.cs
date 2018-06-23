using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using PutridParrot.Music;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            var client = new MusicService.MusicServiceClient(channel);

            var request = new NotesRequest
            {
                Key = Note.C,
                Name = "Major"
            };

            var response = client.Query(request);

            foreach (var note in response.Notes)
            {
                Console.WriteLine(note);
            }
      
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
    }
}
