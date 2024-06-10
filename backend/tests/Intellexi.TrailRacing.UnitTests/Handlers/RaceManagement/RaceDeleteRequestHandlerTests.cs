using FluentAssertions;
using Intellexi.TrailRacing.Application.RaceManagement.Handlers;
using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.UnitTests.Fixtures.RaceManagement;
using NSubstitute;

namespace Intellexi.TrailRacing.UnitTests.Handlers.RaceManagement;

internal class RaceDeleteRequestHandlerTests : RaceDeleteRequestHandlerTestFixture
{
    [TestCaseSource(nameof(Ctor_ShouldThrowArgumentNullException_TestCases))]
    public void Ctor_ShouldThrowArgumentNullException(IMessageSender messageSender)
    {
        // Act
        Action action = () => new RaceDeleteRequestHandler(messageSender);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestCaseSource(nameof(Handle_ShouldHandleSuccessfully_TestCases))]
    public async Task Handle_ShouldHandleSuccessfully(RaceDeleteRequest request)
    {
        // Act
        await Handler.Handle(request, CancellationToken.None);

        // Assert
        MessageSender.Received(1).Send(request);
    }
}