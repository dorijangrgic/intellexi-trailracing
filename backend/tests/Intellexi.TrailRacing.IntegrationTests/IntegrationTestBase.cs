using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.Domain.Entities;
using Intellexi.TrailRacing.Persistence;
using Intellexi.TrailRacing.QueryService.IntegrationTest.WebApplicationFactories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Intellexi.TrailRacing.QueryService.IntegrationTest;

internal abstract class IntegrationTestBase
{
	private IServiceScope _scope;
    private CommandServiceApplicationFactory _commandServiceFactory;
    private QueryServiceApplicationFactory _queryServiceFactory;

    protected HttpClient CommandClient;
    protected HttpClient QueryClient;
    
    protected TrailRacingDbContext DbContext => _scope.ServiceProvider.GetRequiredService<TrailRacingDbContext>();
    protected IMessageSender MessageSender => _scope.ServiceProvider.GetRequiredService<IMessageSender>();
    protected IConfiguration Configuration => _scope.ServiceProvider.GetRequiredService<IConfiguration>();

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _commandServiceFactory = new CommandServiceApplicationFactory();
        _queryServiceFactory = new QueryServiceApplicationFactory();
        
        CommandClient = _commandServiceFactory.CreateClient();
        QueryClient = _queryServiceFactory.CreateClient();
    }

    [SetUp]
    public virtual async Task TestSetUp()
    {
        // Create a scope for test context to obtain a reference to the database context.
        _scope = _commandServiceFactory.Services.CreateScope();

        // Clean database data and setup client before tests
        await CleanDatabaseAsync();
    }

    [TearDown]
    public virtual async Task TearDown()
    {
        TestContext.WriteLine($"{TestContext.CurrentContext.Test.MethodName}:{Environment.NewLine}{_commandServiceFactory.TestLoggerOutput}");
        _commandServiceFactory.TestLoggerOutput.Clear();

        await CleanDatabaseAsync();
        _scope.Dispose();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        CommandClient.Dispose();
        QueryClient.Dispose();
        
        _commandServiceFactory.Dispose();
        _queryServiceFactory.Dispose();
    }

    protected async Task SendAsync(IRequest request)
    {
        var mediator = _scope.ServiceProvider.GetRequiredService<ISender>();

        await mediator.Send(request);
    }

    protected async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        var mediator = _scope.ServiceProvider.GetRequiredService<ISender>();

        return await mediator.Send(request);
    }

    protected async Task<TEntity> FindAsync<TEntity>(params object[] keyValues)
        where TEntity : class => await DbContext.FindAsync<TEntity>(keyValues);

    protected async Task AddAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        var context = DbContext;
        context.Add(entity);
        await context.SaveChangesAsync();
    }

    protected async Task RemoveAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        var context = DbContext;
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    protected Task<T> ExecuteDbContextAsync<T>(Func<TrailRacingDbContext, Task<T>> action) => action(DbContext);

    protected Task<int> InsertAsync<T>(params T[] entities) where T : class
    {
        return ExecuteDbContextAsync(db =>
        {
            foreach (var entity in entities)
            {
                db.Set<T>().Add(entity);
            }
            return db.SaveChangesAsync();
        });
    }

    private async Task CleanDatabaseAsync()
    {
        await DbContext.Set<Race>().ExecuteDeleteAsync();
        await DbContext.Set<Domain.Entities.Application>().ExecuteDeleteAsync();

        await DbContext.SaveChangesAsync();
    }
}