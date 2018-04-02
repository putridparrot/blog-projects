using Newtonsoft.Json;

namespace RefitClient
{
    public class HelloResponse
    {
        [JsonProperty("Result")]
        public string Result { get; set; }
    }
}