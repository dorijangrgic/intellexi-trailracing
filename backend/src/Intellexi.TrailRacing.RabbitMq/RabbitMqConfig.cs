namespace Intellexi.TrailRacing.RabbitMq;

public class RabbitMqConfig
{
    public const string Section = "RabbitMq";
    
    public string Host { get; set; }
    public string QueueName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}