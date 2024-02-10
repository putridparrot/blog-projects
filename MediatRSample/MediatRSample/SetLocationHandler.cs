using MediatR;

namespace MediatRSample;

public class UpdateHandler1 : INotificationHandler<SetLocation>
{
    public Task Handle(SetLocation notification, CancellationToken cancellationToken)
    {
        Console.WriteLine(nameof(UpdateHandler1));
        return Task.CompletedTask;
    }
}

public class UpdateHandler2 : INotificationHandler<SetLocation>
{
    public Task Handle(SetLocation notification, CancellationToken cancellationToken)
    {
        Console.WriteLine(nameof(UpdateHandler2));
        return Task.CompletedTask;
    }
}