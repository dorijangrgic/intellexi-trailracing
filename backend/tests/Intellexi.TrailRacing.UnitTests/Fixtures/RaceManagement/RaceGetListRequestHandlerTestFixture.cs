using Intellexi.TrailRacing.Application.RaceManagement.Handlers;
using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Application.RaceManagement.Responses;
using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.Domain;
using Intellexi.TrailRacing.Domain.Entities;
using Intellexi.TrailRacing.Tests.Shared.Builders.Domain;
using NSubstitute;

namespace Intellexi.TrailRacing.UnitTests.Fixtures.RaceManagement;

internal class RaceGetListRequestHandlerTestFixture
{
    protected IRepository<Race> Repository;
    protected RaceGetListRequestHandler Handler;
    
    [SetUp]
    public void SetUp()
    {
        Repository = Substitute.For<IRepository<Race>>();
        Handler = new RaceGetListRequestHandler(Repository);
    }
    
    protected static IEnumerable<TestCaseData> Ctor_ShouldThrowArgumentNullException_TestCases()
    {
        yield return new TestCaseData(null);
    }
    
    protected static IEnumerable<TestCaseData> Handle_ShouldHandleSuccessfully_TestCases()
    {
        List<Race> races =
        [
            RaceTestBuilder.Default().WithName("Race_1").WithDistance(RaceDistance.FiveKilometers).Build(),
            RaceTestBuilder.Default().WithName("Race_2").WithDistance(RaceDistance.HalfMarathon).Build(),
            RaceTestBuilder.Default().WithName("Race_3").WithDistance(RaceDistance.Marathon).Build()
        ];

        var response = RaceGetListResponse.From(races);
        
        yield return new TestCaseData(new RaceGetListRequest(), races, response);
    }
}