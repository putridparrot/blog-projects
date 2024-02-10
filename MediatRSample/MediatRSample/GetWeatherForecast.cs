using MediatR;

namespace MediatRSample;

public record GetWeatherForecast : IRequest<WeatherForecast[]>
{
    public static GetWeatherForecast Default { get; } = new();
}