using Intellexi.TrailRacing.Persistence;
using Intellexi.TrailRacing.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Intellexi.TrailRacing.QueryService.IntegrationTest.Helpers;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection ReplaceDbContext(this IServiceCollection services)
	{
		// Remove the existing DbContext registration
		var descriptor = services.SingleOrDefault(
			d => d.ServiceType == typeof(DbContextOptions<TrailRacingDbContext>));

		if (descriptor != null)
		{
			services.Remove(descriptor);
		}

		// Add DbContext using the test database connection string
		services.AddDbContext<TrailRacingDbContext>(options =>
		{
			var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
			var connectionString = configuration.GetConnectionString(AppDefaults.Persistence.ConnectionString);

			options.UseNpgsql(connectionString);
		});

		// Ensure the database is created
		var sp = services.BuildServiceProvider();
		using (var scope = sp.CreateScope())
		{
			var scopedServices = scope.ServiceProvider;
			var db = scopedServices.GetRequiredService<TrailRacingDbContext>();
			db.Database.EnsureCreated();
		}

		return services;
	}
}