using Intellexi.TrailRacing.Application.ApplicationManagement.Handlers;
using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;
using Intellexi.TrailRacing.Application.ApplicationManagement.Responses;
using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.Tests.Shared.Builders.Domain;
using NSubstitute;

namespace Intellexi.TrailRacing.UnitTests.Fixtures.ApplicationManagement;

internal class ApplicationGetDetailsRequestHandlerTestFixture
{
    protected IRepository<ApplicationEntity> Repository;
    protected ApplicationGetDetailsRequestHandler Handler;
    
    [SetUp]
    public void SetUp()
    {
        Repository = Substitute.For<IRepository<ApplicationEntity>>();
        Handler = new ApplicationGetDetailsRequestHandler(Repository);
    }
    
    protected static IEnumerable<TestCaseData> Ctor_ShouldThrowArgumentNullException_TestCases()
    {
        yield return new TestCaseData(null);
    }
    
    protected static IEnumerable<TestCaseData> Handle_ShouldHandleSuccessfully_TestCases()
    {
        var application = ApplicationTestBuilder.Default()
            .WithFirstName("Applicant_1")
            .WithLastName("Applicant_1_lastname")
            .WithClub("club")
            .Build();

        var response = ApplicationGetDetailsResponse.From(application);
        
        yield return new TestCaseData(new ApplicationGetDetailsRequest(application.Id), application, response);
    }
}