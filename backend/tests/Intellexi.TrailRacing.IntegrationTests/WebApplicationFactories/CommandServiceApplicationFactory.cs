using System.Text;
using Intellexi.TrailRacing.QueryService.IntegrationTest.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Intellexi.TrailRacing.QueryService.IntegrationTest.WebApplicationFactories;

internal class CommandServiceApplicationFactory : WebApplicationFactory<CommandService.Program>
{
	public readonly StringBuilder TestLoggerOutput = new();
	
	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureAppConfiguration((context, config) =>
		{
			var integrationConfig = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.IntegrationTests.json")
				.Build();

			config.AddConfiguration(integrationConfig);
		});

		builder.ConfigureServices(services =>
		{
			services.ReplaceDbContext();
		});
	}
}