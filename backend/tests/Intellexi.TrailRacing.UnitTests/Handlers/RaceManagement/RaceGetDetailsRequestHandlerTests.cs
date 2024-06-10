using FluentAssertions;
using Intellexi.TrailRacing.Application.RaceManagement.Handlers;
using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Application.RaceManagement.Responses;
using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.Domain.Entities;
using Intellexi.TrailRacing.UnitTests.Fixtures.RaceManagement;
using NSubstitute;

namespace Intellexi.TrailRacing.UnitTests.Handlers.RaceManagement;

internal class RaceGetDetailsRequestHandlerTests : RaceGetDetailsRequestHandlerTestFixture
{
    [TestCaseSource(nameof(Ctor_ShouldThrowArgumentNullException_TestCases))]
    public void Ctor_ShouldThrowArgumentNullException(IRepository<Race> repository)
    {
        // Act
        Action action = () => new RaceGetDetailsRequestHandler(repository);
        
        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestCaseSource(nameof(Handle_ShouldHandleSuccessfully_TestCases))]
    public async Task Handle_ShouldHandleSuccessfully(
        RaceGetDetailsRequest request,
        Race race,
        RaceGetDetailsResponse expectedResponse)
    {
        // Arrange
        Repository.GetByIdAsync(request.RaceId, Arg.Any<CancellationToken>()).Returns(race);
        
        // Act
        var response = await Handler.Handle(request, CancellationToken.None);

        // Assert
        response.Should().BeEquivalentTo(expectedResponse);
    }
}