using ServiceStack;
using RefitExample.ServiceModel;

namespace RefitExample.ServiceInterface
{
    public class MyServices : Service
    {
        [AddHeader(ContentType = MimeTypes.Json)]
        public object Any(Hello request)
        {
            return new HelloResponse { Result = "Hello, {0}!".Fmt(request.Name) };
        }
    }
}