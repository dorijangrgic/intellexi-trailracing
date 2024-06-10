using Intellexi.TrailRacing.Application.ApplicationManagement.Handlers;
using Intellexi.TrailRacing.Tests.Shared.Builders.Requests;

namespace Intellexi.TrailRacing.UnitTests.Fixtures.ApplicationManagement;

internal class ApplicationCreateRequestHandlerTestFixture : BaseRequestHandlerTestFixture<ApplicationCreateRequestHandler>
{
    [SetUp]
    public void SetUp()
    {
        Handler = new ApplicationCreateRequestHandler(MessageSender);
    }

    protected static IEnumerable<TestCaseData> Handle_ShouldHandleSuccessfully_TestCases()
    {
        yield return new TestCaseData(ApplicationCreateRequestTestBuilder.Default().Build());
    }
}