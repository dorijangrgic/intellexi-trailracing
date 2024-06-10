using Intellexi.TrailRacing.Application.Services;
using NSubstitute;

namespace Intellexi.TrailRacing.UnitTests.Fixtures;

internal class BaseRequestHandlerTestFixture<T>
{
    protected T Handler;
    protected IMessageSender MessageSender;
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        MessageSender = Substitute.For<IMessageSender>();
    }
    
    protected static IEnumerable<TestCaseData> Ctor_ShouldThrowArgumentNullException_TestCases()
    {
        yield return new TestCaseData(null);
    }
}