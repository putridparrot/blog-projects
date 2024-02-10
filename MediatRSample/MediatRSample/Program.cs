
using MediatR;

namespace MediatRSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapGet("/weatherforecast",  async (IMediator mediator) => 
                await mediator.Send(GetWeatherForecast.Default) is var results 
                    ? Results.Ok(results) 
                    : Results.NotFound())
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            app.MapGet("/setlocation", (IMediator mediator, string location) =>
                    mediator.Publish(new SetLocation(location)))
                .WithName("SetLocation")
                .WithOpenApi();

            app.Run();
        }
    }
}
