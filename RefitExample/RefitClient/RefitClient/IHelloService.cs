using System.Threading.Tasks;
using Refit;

namespace RefitClient
{
    public interface IHelloService
    {
        [Get("/hello/{name}")]
        Task<HelloResponse> SayHello(string name);
    }
}