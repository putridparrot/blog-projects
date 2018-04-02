using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                HostName = "192.168.0.248",
                Port = AmqpTcpEndpoint.UseDefaultPort
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);

                    var message = "Hello World";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(String.Empty, "hello", null,body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }
            Console.ReadLine();
        }
    }
}
