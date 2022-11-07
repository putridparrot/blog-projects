

using System.Threading;
using System;
using nanoFramework.WebServer;
using System.Net;

namespace M5Core2Examples.Server
{
    public static class M5WebServer
    {
        public static void Run()
        {
            using WebServer server = new WebServer(80, HttpProtocol.Http, new[] { typeof(TestController) });

            server.Start();

            Thread.Sleep(Timeout.Infinite);
        }
    }

    public class TestController
    {
        [Route("test"), Route("Test2"), Route("tEst42"), Route("TEST")]
        [CaseSensitive]
        [Method("GET")]
        public void RoutePostTest(WebServerEventArgs e)
        {
            string route = $"The route asked is {e.Context.Request.RawUrl.TrimStart('/').Split('/')[0]}";
            e.Context.Response.ContentType = "text/plain";
            WebServer.OutPutStream(e.Context.Response, route);
        }

        [Route("test/any")]
        public void RouteAnyTest(WebServerEventArgs e)
        {
            WebServer.OutputHttpCode(e.Context.Response, HttpStatusCode.OK);
        }
    }
}
