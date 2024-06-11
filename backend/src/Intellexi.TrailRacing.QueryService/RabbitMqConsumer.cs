using System.Net.Sockets;
using System.Text;
using Intellexi.TrailRacing.QueryService.MessageHandlers;
using Intellexi.TrailRacing.RabbitMq;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

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
        EstablishConnection();
        _channel = _connection.CreateModel();

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) => await HandleReceivedMessage(model, ea);

        _channel.BasicConsume(
            queue: _config.QueueName,
            autoAck: true,
            consumer: consumer);

        return Task.CompletedTask;
    }

    private void EstablishConnection()
    {
        var factory = new ConnectionFactory
        {
            HostName = _config.Host,
            UserName = _config.Username,
            Password = _config.Password
        };

        var retryPolicy = Policy
            .Handle<SocketException>()
            .Or<BrokerUnreachableException>()
            .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        retryPolicy.Execute(() => _connection = factory.CreateConnection());
        // _connection = factory.CreateConnection();
    }

    private async Task HandleReceivedMessage(object _, BasicDeliverEventArgs eventArgs)
    {
        var body = eventArgs.Body.ToArray();
        var message = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(body));

        try
        {
            using var scope = _serviceProvider.CreateScope();
            var messageType = message.GetType();
            var handlerType = typeof(IMessageHandler<>).MakeGenericType(messageType);
            var handler = scope.ServiceProvider.GetService(handlerType);
            await (Task)handler?.GetType().GetMethod("HandleAsync")?.Invoke(handler, [message]);
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