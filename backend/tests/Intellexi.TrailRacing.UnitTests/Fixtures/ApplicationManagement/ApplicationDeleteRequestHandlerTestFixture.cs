using Intellexi.TrailRacing.Application.ApplicationManagement.Handlers;
using Intellexi.TrailRacing.Tests.Shared.Builders.Requests;

namespace Intellexi.TrailRacing.UnitTests.Fixtures.ApplicationManagement;

internal class ApplicationDeleteRequestHandlerTestFixture : BaseRequestHandlerTestFixture<ApplicationDeleteRequestHandler>
{
    [SetUp]
    public void SetUp()
    {
        Handler = new ApplicationDeleteRequestHandler(MessageSender);
    }

    protected static IEnumerable<TestCaseData> Handle_ShouldHandleSuccessfully_TestCases()
    {
        yield return new TestCaseData(ApplicationDeleteRequestTestBuilder.Default().Build());
    }
}