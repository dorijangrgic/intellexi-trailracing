using FluentAssertions;
using Intellexi.TrailRacing.Application.ApplicationManagement.Handlers;
using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;
using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.UnitTests.Fixtures.ApplicationManagement;
using NSubstitute;

namespace Intellexi.TrailRacing.UnitTests.Handlers.ApplicationManagement;

internal class ApplicationCreateRequestHandlerTests : ApplicationCreateRequestHandlerTestFixture
{
    [TestCaseSource(nameof(Ctor_ShouldThrowArgumentNullException_TestCases))]
    public void Ctor_ShouldThrowArgumentNullException(IMessageSender messageSender)
    {
        // Act
        Action action = () => new ApplicationCreateRequestHandler(messageSender);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestCaseSource(nameof(Handle_ShouldHandleSuccessfully_TestCases))]
    public async Task Handle_ShouldHandleSuccessfully(ApplicationCreateRequest request)
    {
        // Act
        await Handler.Handle(request, CancellationToken.None);

        // Assert
        MessageSender.Received(1).Send(request);
    }
}