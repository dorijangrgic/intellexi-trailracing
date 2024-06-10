using System.Text;
using Intellexi.TrailRacing.RabbitMq;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Intellexi.TrailRacing.QueryService;

public class RabbitMqConsumer : IHostedService, IDisposable
{
    private IConnection _connection;
    private IModel _channel;
    private readonly RabbitMqConfig _config;

    public RabbitMqConsumer(IOptions<RabbitMqConfig> config)
    {
        _config = config.Value;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var factory = new ConnectionFactory
        {
            HostName = _config.Host,
            UserName = _config.Username,
            Password = _config.Password
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Received message: {message}");

            // deserialize message to a domain message object and call appropriate handler
        };

        _channel.BasicConsume(
            queue: _config.QueueName,
            autoAck: true,
            consumer: consumer);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _channel?.Close();
        _connection?.Close();
        return Task.CompletedTask;
    }
    
    public void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
    }
}