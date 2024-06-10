using Intellexi.TrailRacing.Application.RaceManagement.Handlers;
using Intellexi.TrailRacing.Tests.Shared.Builders.Requests;

namespace Intellexi.TrailRacing.UnitTests.Fixtures.RaceManagement;

internal class RaceDeleteRequestHandlerTestFixture : BaseRequestHandlerTestFixture<RaceDeleteRequestHandler>
{
    [SetUp]
    public void SetUp()
    {
        Handler = new RaceDeleteRequestHandler(MessageSender);
    }

    protected static IEnumerable<TestCaseData> Handle_ShouldHandleSuccessfully_TestCases()
    {
        yield return new TestCaseData(RaceDeleteRequestTestBuilder.Default().Build());
    }
}