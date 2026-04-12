using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Text("SSE server is running. Connect to /events for a stream."));

app.MapGet("/events", async (HttpContext context, CancellationToken cancellationToken) =>
{
    context.Response.ContentType = "text/event-stream";
    context.Response.Headers.CacheControl = "no-cache";

    try
    {
        for (var i = 1; i <= 20; i++)
        {
            var payload = JsonSerializer.Serialize(new
            {
                id = i,
                message = $"Server tick {i}",
                sentAtUtc = DateTimeOffset.UtcNow
            });

            await context.Response.WriteAsync($"id: {i}\n", cancellationToken);
            await context.Response.WriteAsync("event: tick\n", cancellationToken);
            await context.Response.WriteAsync($"data: {payload}\n\n", cancellationToken);
            await context.Response.Body.FlushAsync(cancellationToken);

            await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
        }
    }
    catch (OperationCanceledException)
    {
    }
});

app.Run();
