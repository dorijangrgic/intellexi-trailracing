using Intellexi.TrailRacing.Application.ApplicationManagement.Handlers;
using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;
using Intellexi.TrailRacing.Application.ApplicationManagement.Responses;
using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.Tests.Shared.Builders.Domain;
using NSubstitute;

namespace Intellexi.TrailRacing.UnitTests.Fixtures.ApplicationManagement;

internal class ApplicationGetListRequestHandlerTestFixture
{
    protected IRepository<ApplicationEntity> Repository;
    protected ApplicationGetListRequestHandler Handler;
    
    [SetUp]
    public void SetUp()
    {
        Repository = Substitute.For<IRepository<ApplicationEntity>>();
        Handler = new ApplicationGetListRequestHandler(Repository);
    }
    
    protected static IEnumerable<TestCaseData> Ctor_ShouldThrowArgumentNullException_TestCases()
    {
        yield return new TestCaseData(null);
    }
    
    protected static IEnumerable<TestCaseData> Handle_ShouldHandleSuccessfully_TestCases()
    {
        List<ApplicationEntity> applications =
        [
            ApplicationTestBuilder.Default()
                .WithFirstName("Applicant_1")
                .WithLastName("Applicant_1_lastname")
                .WithClub("Club_1")
                .Build(),
            ApplicationTestBuilder.Default()
                .WithFirstName("Applicant_1")
                .WithLastName("Applicant_1_lastname")
                .WithClub("Club_1")
                .Build(),
            ApplicationTestBuilder.Default()
                .WithFirstName("Applicant_1")
                .WithLastName("Applicant_1_lastname")
                .WithClub("Club_1")
                .Build(),
            
        ];

        var response = ApplicationGetListResponse.From(applications);
        
        yield return new TestCaseData(new ApplicationGetListRequest(), applications, response);
    }
}