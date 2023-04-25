using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Text;

namespace Board.Host.Consumer
{
    public class RabbitMqConsumer : IRabbitMqConsumer
    {
        private readonly IConfiguration _сonfiguration;
        private readonly ILogger<RabbitMqConsumer> _logger;

        public RabbitMqConsumer(IConfiguration сonfiguration, ILogger<RabbitMqConsumer> logger)
        {
            _сonfiguration = сonfiguration;
            _logger = logger;
        }

        public async Task Consume()
        {
            var factory = new ConnectionFactory { HostName = _сonfiguration.GetSection("RabbitMq:HostName").Value };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "test_queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                _logger.LogInformation("Start recieving message");

                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                _logger.LogWarning("Message received");

                Console.WriteLine($" [x] Received {message}");
            };

            channel.BasicConsume(queue: "test_queue",
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
