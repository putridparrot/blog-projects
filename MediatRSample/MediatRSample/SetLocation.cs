using MediatR;

namespace MediatRSample;

public record SetLocation(string Location) : INotification;
