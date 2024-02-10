using MediatR;
using System.Runtime.CompilerServices;

namespace MediatRSample;

public class GetWeatherStreamHandler : IStreamRequestHandler<GetWeatherStream, WeatherForecast>
{
    public async IAsyncEnumerable<WeatherForecast> Handle(GetWeatherStream request, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var index = 0;
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(500, cancellationToken);
            yield return new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Data.Summaries[Random.Shared.Next(Data.Summaries.Length)]
            };

            index++;
            if(index > 10)
                break;
        }
    }
}