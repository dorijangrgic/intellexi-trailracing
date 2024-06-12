using Testcontainers.PostgreSql;
using Testcontainers.RabbitMq;

namespace Intellexi.TrailRacing.QueryService.IntegrationTest;

[SetUpFixture]
internal class SetUpFixture
{
	private static PostgreSqlContainer _postgreSqlContainer;
	private static RabbitMqContainer _rabbitMqContainer;
	
	[OneTimeSetUp]
	public async Task OneTimeSetUp()
	{
		await Task.WhenAll(
			SetupPostgreSqlContainer(),
			SetupRabbitMqContainer());
	}

	[OneTimeTearDown]
	public async Task OneTimeTearDown()
	{
		await _postgreSqlContainer.DisposeAsync();
		await _rabbitMqContainer.DisposeAsync();
	}

	private static async Task SetupPostgreSqlContainer()
	{
		_postgreSqlContainer = new PostgreSqlBuilder()
			.WithImage("postgres:15.1")
			.WithCleanUp(true)
			.WithPortBinding(15432, 5432)
			.WithDatabase("tests")
			.WithUsername("postgres")
			.WithPassword("Pa$$word01")
			.Build();

		await _postgreSqlContainer.StartAsync();
	}

	private static async Task SetupRabbitMqContainer()
	{
		_rabbitMqContainer = new RabbitMqBuilder()
			.WithImage("rabbitmq:3-management")
			.WithUsername("admin")
			.WithPassword("admin")
			.WithCleanUp(true)
			.WithPortBinding(15672, 15672)
			.WithPortBinding(5672, 5672)
			.WithResourceMapping(
				new FileInfo(".files/rabbitmq/definitions.json"),
				new FileInfo("/etc/rabbitmq/conf.d/definitions.json"))
			.WithResourceMapping(
				new FileInfo(".files/rabbitmq/rabbitmq.conf"),
				new FileInfo("/etc/rabbitmq/conf.d/rabbitmq.conf"))
			.Build();
		
		await _rabbitMqContainer.StartAsync();
	}
}