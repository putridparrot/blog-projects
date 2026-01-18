
var builder = WebApplication.CreateBuilder(args);

// Ensure Application Insights captures Information and above
//builder.Logging.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>(
//    "", LogLevel.Information);

builder.Services.AddOpenApi();

builder.Services.AddApplicationInsightsTelemetry();

//builder.Services.AddApplicationInsightsTelemetry(options =>
//{
//    options.EnableAdaptiveSampling = false;
//    options.EnableDebugLogger = true;
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", (ILogger<Program> logger) =>
{
    logger.LogWarning("This is a warning10");
    logger.LogInformation("Hello endpoint called10");
    return "Hello";
});

app.Run();
