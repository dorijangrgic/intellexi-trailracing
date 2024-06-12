using Intellexi.TrailRacing.Application.RaceManagement.Handlers;
using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Application.RaceManagement.Responses;
using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.Domain;
using Intellexi.TrailRacing.Domain.Entities;
using Intellexi.TrailRacing.Tests.Shared.Builders.Domain;
using NSubstitute;

namespace Intellexi.TrailRacing.UnitTests.Fixtures.RaceManagement;

internal class RaceGetDetailsRequestHandlerTestFixture
{
    protected IRepository<Race> Repository;
    protected RaceGetDetailsRequestHandler Handler;
    
    [SetUp]
    public void SetUp()
    {
        Repository = Substitute.For<IRepository<Race>>();
        Handler = new RaceGetDetailsRequestHandler(Repository);
    }
    
    protected static IEnumerable<TestCaseData> Ctor_ShouldThrowArgumentNullException_TestCases()
    {
        yield return new TestCaseData(null);
    }
    
    protected static IEnumerable<TestCaseData> Handle_ShouldHandleSuccessfully_TestCases()
    {
        var race = RaceTestBuilder.Default().WithName("Race_1").WithDistance(RaceDistance.FiveKilometers).Build();

        var response = RaceGetDetailsResponse.From(race);
        
        yield return new TestCaseData(new RaceGetDetailsRequest(race.Id), race, response);
    }
}