using Intellexi.TrailRacing.Application.RaceManagement.Handlers;
using Intellexi.TrailRacing.Tests.Shared.Builders.Requests;

namespace Intellexi.TrailRacing.UnitTests.Fixtures.RaceManagement;

internal class RaceCreateRequestHandlerTestFixture : BaseRequestHandlerTestFixture<RaceCreateRequestHandler>
{
    [SetUp]
    public void SetUp()
    {
        Handler = new RaceCreateRequestHandler(MessageSender);
    }

    protected static IEnumerable<TestCaseData> Handle_ShouldHandleSuccessfully_TestCases()
    {
        yield return new TestCaseData(RaceCreateRequestTestBuilder.Default().Build());
    }
}