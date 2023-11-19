using Confluent.Kafka;

var config = new List<KeyValuePair<string, string>>
{
    new("bootstrap.servers", "192.168.0.88:19092"),
    new("client.id", "my-producer")
};

const string topic = "my-topic";

string[] tickers = { "AAPL", "GOOGL", "MSFT", "AMZN", "META", "TSLA", "GS" };
string[] trades = { "Buy 100", "Sell 1000", "Buy 9090", "Sell 45", "Buy 900000", "Sell 123", "Buy 8901" };

using var producer = new ProducerBuilder<string, string>(config).Build();

var rnd = new Random();

for (var i = 0; i < 10; ++i)
{
    var ticker = tickers[rnd.Next(tickers.Length)];
    var trade = trades[rnd.Next(trades.Length)];

    producer.Produce(topic, new Message<string, string> { Key = ticker, Value = trade },
        deliveryReport =>
        {
            if (deliveryReport.Error.Code != ErrorCode.NoError)
            {
                Console.WriteLine($"Error sending event: {deliveryReport.Error.Reason}");
            }
            else
            {
                Console.WriteLine($"Sent event topic = {topic}: key = {ticker} value = {trade}");
            }
        });
}

producer.Flush(TimeSpan.FromSeconds(10));
