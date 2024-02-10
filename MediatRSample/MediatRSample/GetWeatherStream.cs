using MediatR;

namespace MediatRSample;

public record GetWeatherStream : IStreamRequest<WeatherForecast>;