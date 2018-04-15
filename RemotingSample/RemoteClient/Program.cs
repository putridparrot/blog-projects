using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemotingServer;

namespace RemoteClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = (IRemoteService)Activator.GetObject(
                typeof(IRemoteService),
                "tcp://localhost:1002/Remote");

            obj.Write("Hello World");
        }
    }
}
