using Orleans.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Host.UseOrleans(silo =>
{
    silo.UseLocalhostClustering();
    silo.AddMemoryGrainStorage("documentStore");
    silo.UseDashboard(options =>
    {
        options.HostSelf = true;
        options.Port = 7000;
    });

    silo.UseKubernetesHosting();
    //silo.UseKubeMembership(); // from Orleans.Clustering.Kubernetes
    silo.ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000);
});

//builder.Services.AddOrleansClient(client =>
//{
//    // Local dev clustering
//    client.UseLocalhostClustering();

//    // For production (AKS, cloud), replace with:
//    // client.UseAzureStorageClustering(options =>
//    // {
//    //     options.ConnectionString = builder.Configuration["Orleans:Clustering:ConnectionString"];
//    // });
//});


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseHttpMetrics();
//app.MapMetrics(); // exposes /metrics endpoint


app.Run();
