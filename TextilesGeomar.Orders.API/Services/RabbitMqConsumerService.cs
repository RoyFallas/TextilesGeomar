using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Interfaces.Services;

namespace TextilesGeomar.Orders.API.Services
{
    public class RabbitMqConsumerService : IHostedService
    {
        private readonly ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public RabbitMqConsumerService(IServiceProvider serviceProvider)
        {
            _factory = new ConnectionFactory()
            {
                HostName = "localhost",  // Replace with actual RabbitMQ host
                Port = 5672,
            };
            _serviceProvider = serviceProvider;
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

            consumer.ReceivedAsync += async (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                // Deserialize JSON message to Order object
                try
                {
                    var order = JsonSerializer.Deserialize<Order>(message);

                    if (order != null)
                    {
                        // Process the order (for example, log the details)
                        Console.WriteLine($"Received Order: Item ID = {order.ItemId}, Uniform ID = {order.UniformId}, Client ID = {order.ClientId}, Institution ID = {order.InstitutionId}, Status ID = {order.StatusId}, Created Date = {order.CreatedDate}, Completed Date = {order.CompletedDate?.ToString() ?? "null"}");

                        // Create a new scope and resolve IOrderService
                        using (var scope = _serviceProvider.CreateScope())
                        {
                            var consumerOrderService = scope.ServiceProvider.GetRequiredService<IConsumeOrderService>();
                            await consumerOrderService.SaveOrder(order);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Order message could not be deserialized.");
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error deserializing order: {ex.Message}");
                }
            };

            await channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
