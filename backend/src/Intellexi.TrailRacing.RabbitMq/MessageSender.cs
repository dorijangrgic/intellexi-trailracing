using System.Text;
using Intellexi.TrailRacing.Application.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Intellexi.TrailRacing.RabbitMq;

public class MessageSender : IMessageSender, IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly RabbitMqConfig _config;

    public MessageSender(IOptions<RabbitMqConfig> config)
    {
        _config = config.Value;

        var factory = new ConnectionFactory
        {
            HostName = _config.Host,
            UserName = _config.Username,
            Password = _config.Password
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public void Send<T>(T message)
    {
        var jsonBody = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(jsonBody);
        _channel.BasicPublish(
            exchange: "",
            routingKey: _config.QueueName,
            basicProperties: null,
            body: body);
    }

    public void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
    }
}