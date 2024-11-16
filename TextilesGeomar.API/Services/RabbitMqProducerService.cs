using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Interfaces.Services;

namespace TextilesGeomar.API.Services
{
    public class RabbitMqProducerService : IRabbitMqProducerService
    {
        private readonly ConnectionFactory _factory;

        public RabbitMqProducerService()
        {
            _factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
            };
        }

        public async Task SendOrderToQueueAsync(Order order)
        {
            using var connection = await _factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "orderQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var message = JsonSerializer.Serialize(order);
            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "orderQueue", body: body);
            Console.WriteLine($" [x] Sent {message}");
        }
    }
}
