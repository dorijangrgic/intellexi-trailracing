using Intellexi.TrailRacing.Application.RaceManagement.Handlers;
using Intellexi.TrailRacing.Tests.Shared.Builders.Requests;

namespace Intellexi.TrailRacing.UnitTests.Fixtures.RaceManagement;

internal class RaceUpdateRequestHandlerTestFixture : BaseRequestHandlerTestFixture<RaceUpdateRequestHandler>
{
    [SetUp]
    public void SetUp()
    {
        Handler = new RaceUpdateRequestHandler(MessageSender);
    }

    protected static IEnumerable<TestCaseData> Handle_ShouldHandleSuccessfully_TestCases()
    {
        yield return new TestCaseData(RaceUpdateRequestTestBuilder.Default().Build());
    }
}