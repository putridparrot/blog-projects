using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemotingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = new TcpChannel(1002);
            ChannelServices.RegisterChannel(channel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(RemoteService),
                "Remote",
                WellKnownObjectMode.Singleton);

            // now let's ensure the console remains open
            Console.ReadLine();
        }
    }
}
