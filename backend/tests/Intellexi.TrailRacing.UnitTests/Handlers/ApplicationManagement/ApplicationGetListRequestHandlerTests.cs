using FluentAssertions;
using Intellexi.TrailRacing.Application.ApplicationManagement.Handlers;
using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;
using Intellexi.TrailRacing.Application.ApplicationManagement.Responses;
using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.UnitTests.Fixtures.ApplicationManagement;
using NSubstitute;

namespace Intellexi.TrailRacing.UnitTests.Handlers.ApplicationManagement;

internal class ApplicationGetListRequestHandlerTests : ApplicationGetListRequestHandlerTestFixture
{
    [TestCaseSource(nameof(Ctor_ShouldThrowArgumentNullException_TestCases))]
    public void Ctor_ShouldThrowArgumentNullException(IRepository<ApplicationEntity> repository)
    {
        // Act
        Action action = () => new ApplicationGetListRequestHandler(repository);
        
        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestCaseSource(nameof(Handle_ShouldHandleSuccessfully_TestCases))]
    public async Task Handle_ShouldHandleSuccessfully(
        ApplicationGetListRequest request,
        List<ApplicationEntity> Applications,
        ApplicationGetListResponse expectedResponse)
    {
        // Arrange
        Repository.ListAsync(Arg.Any<CancellationToken>()).Returns(Applications.ToList());
        
        // Act
        var response = await Handler.Handle(request, CancellationToken.None);

        // Assert
        response.Should().BeEquivalentTo(expectedResponse);
    }
}