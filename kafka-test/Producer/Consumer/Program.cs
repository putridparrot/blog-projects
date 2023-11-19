using Confluent.Kafka;

var config = new List<KeyValuePair<string, string>>
        {
            new("bootstrap.servers", "192.168.0.88:19092"),
            new("group.id", "my-group"),
            new("auto.offset.reset", "earliest")
        };

const string topic = "my-topic";

var cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true; // prevent the process from terminating.
    cts.Cancel();
};

using var consumer = new ConsumerBuilder<string, string>(config)
    .SetPartitionsAssignedHandler((c, partitions) =>
    {
        // reset the offsets for this client
        var offsets = partitions.Select(tp => new TopicPartitionOffset(tp, Offset.Beginning));
        return offsets;
    })
    .Build();

consumer.Subscribe(topic);
try
{
    while (true)
    {
        var cr = consumer.Consume(cts.Token);
        Console.WriteLine($"Consumed event, topic {topic}: key = {cr.Message.Key} value = {cr.Message.Value}");
    }
}
catch (OperationCanceledException)
{
    // Ctrl-C was pressed.
}
finally
{
    consumer.Close();
}
