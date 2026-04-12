using System.Net.Http.Headers;
using System.Text;

var serverUrl = args.Length > 0 ? args[0] : "http://localhost:5127";

using var cancellation = new CancellationTokenSource();
Console.CancelKeyPress += (_, eventArgs) =>
{
    eventArgs.Cancel = true;
    cancellation.Cancel();
};

using var httpClient = new HttpClient
{
    BaseAddress = new Uri(serverUrl)
};

using var request = new HttpRequestMessage(HttpMethod.Get, "/events");
request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));

Console.WriteLine($"Connecting to SSE endpoint at {httpClient.BaseAddress}events");
Console.WriteLine("Press Ctrl+C to stop.\n");

using var response = await httpClient.SendAsync(
    request,
    HttpCompletionOption.ResponseHeadersRead,
    cancellation.Token);

response.EnsureSuccessStatusCode();

await using var stream = await response.Content.ReadAsStreamAsync(cancellation.Token);
using var reader = new StreamReader(stream);

var eventId = string.Empty;
var eventName = string.Empty;
var eventDataBuilder = new StringBuilder();

while (!cancellation.IsCancellationRequested)
{
    var line = await reader.ReadLineAsync(cancellation.Token);

    if (line is null)
    {
        break;
    }

    if (line.Length == 0)
    {
        if (eventDataBuilder.Length > 0)
        {
            Console.WriteLine($"[{DateTime.Now:T}] id={eventId}, event={eventName}, data={eventDataBuilder}");
        }

        eventId = string.Empty;
        eventName = string.Empty;
        eventDataBuilder.Clear();
        continue;
    }

    if (line.StartsWith("id: ", StringComparison.Ordinal))
    {
        eventId = line[4..];
        continue;
    }

    if (line.StartsWith("event: ", StringComparison.Ordinal))
    {
        eventName = line[7..];
        continue;
    }

    if (line.StartsWith("data: ", StringComparison.Ordinal))
    {
        if (eventDataBuilder.Length > 0)
        {
            eventDataBuilder.Append('\n');
        }

        eventDataBuilder.Append(line[6..]);
    }
}

Console.WriteLine("SSE client stopped.");
