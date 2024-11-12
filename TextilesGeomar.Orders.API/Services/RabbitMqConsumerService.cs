using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TextilesGeomar.Models.DTOs;
using TextilesGeomar.Services;

namespace TextilesGeomar.Orders.API.Services
{
    public class RabbitMqConsumerService : IHostedService
    {
        private readonly ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMqConsumerService()
        {
            _factory = new ConnectionFactory()
            {
                HostName = "localhost",  // Replace with actual RabbitMQ host
                Port = 5672,
            };
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Create connection and channel
            var connection = await _factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            // Declare an exchange (logs in this case)
            await channel.ExchangeDeclareAsync(exchange: "logs", type: ExchangeType.Fanout);

            // Declare an anonymous queue and bind it to the exchange
            var queueDeclareResult = await channel.QueueDeclareAsync(queue: "orderQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            string queueName = queueDeclareResult.QueueName;
            await channel.QueueBindAsync(queue: "orderQueue", exchange: "logs", routingKey: string.Empty);

            // Setup an async consumer for handling incoming messages
            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");
                return Task.CompletedTask;
            };

            await channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
