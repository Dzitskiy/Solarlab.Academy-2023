using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Board.Application.AppData.Services
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IConfiguration _сonfiguration;

        public RabbitMqService(IConfiguration сonfiguration)
        {
            _сonfiguration = сonfiguration;
        }

        public void SendMessage(object obj)
        {
            var message = JsonSerializer.Serialize(obj);
            SendMessage(message);
        }

        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = _сonfiguration.GetSection("RabbitMq:HostName").Value };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var props = channel.CreateBasicProperties();

                // Persistent delivery mode.
                props.DeliveryMode = 2;

                channel.QueueDeclare(queue: "board_queue",
                               durable: false,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: string.Empty,
                               routingKey: "board_queue",
                               basicProperties: null,
                               body: body);
            }
        }
    }
}
