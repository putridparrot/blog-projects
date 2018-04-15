using System;

namespace RemotingServer
{
    public class RemoteService : MarshalByRefObject, IRemoteService
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
