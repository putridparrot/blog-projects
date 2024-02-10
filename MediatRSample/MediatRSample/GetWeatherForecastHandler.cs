using MediatR;

namespace MediatRSample;

public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecast, WeatherForecast[]>
{
    public Task<WeatherForecast[]> Handle(GetWeatherForecast request, CancellationToken cancellationToken)
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Data.Summaries[Random.Shared.Next(Data.Summaries.Length)]
                })
            .ToArray();

        return Task.FromResult(forecast);
    }
}