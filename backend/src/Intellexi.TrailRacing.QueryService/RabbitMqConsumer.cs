using System.Text;
using Intellexi.TrailRacing.QueryService.MessageHandlers;
using Intellexi.TrailRacing.RabbitMq;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Intellexi.TrailRacing.QueryService;

public class RabbitMqConsumer : IHostedService, IDisposable
{
    private IConnection _connection;
    private IModel _channel;
    private readonly RabbitMqConfig _config;
    private readonly IServiceProvider _serviceProvider;

    public RabbitMqConsumer(
        IOptions<RabbitMqConfig> config,
        IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(config);
        ArgumentNullException.ThrowIfNull(serviceProvider);

        _config = config.Value;
        _serviceProvider = serviceProvider;
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
        consumer.Received += async (model, ea) => await HandleReceivedMessage(model, ea);

        _channel.BasicConsume(
            queue: _config.QueueName,
            autoAck: true,
            consumer: consumer);

        return Task.CompletedTask;
    }

    private async Task HandleReceivedMessage(object _, BasicDeliverEventArgs eventArgs)
    {
        var body = eventArgs.Body.ToArray();
        var message = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(body));

        try
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var messageType = message.GetType();
                var handlerType = typeof(IMessageHandler<>).MakeGenericType(messageType);
                var handler = scope.ServiceProvider.GetService(handlerType);
                if (handler != null)
                {
                    var method = handler.GetType().GetMethod("HandleAsync");
                    if (method != null)
                    {
                        await (Task)method.Invoke(handler, [message]);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
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