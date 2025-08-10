using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/echo", (string text) =>
    {
        app.Logger.LogInformation($"C# Echo: {text}");
        return $"C# Echo: {text}";
    })
    .WithName("Echo")
    .WithOpenApi();

app.MapHealthChecks("/livez");
app.MapHealthChecks("/readyz", new HealthCheckOptions
{
    Predicate = _ => true
});

app.Run();