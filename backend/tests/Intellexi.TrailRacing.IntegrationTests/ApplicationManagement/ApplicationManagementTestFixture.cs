using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;
using Intellexi.TrailRacing.Application.ApplicationManagement.Responses;
using Intellexi.TrailRacing.Shared;
using Intellexi.TrailRacing.Tests.Shared.Builders.Domain;
using Intellexi.TrailRacing.Tests.Shared.Builders.Requests;

namespace Intellexi.TrailRacing.QueryService.IntegrationTest.ApplicationManagement;

internal class ApplicationManagementTestFixture : IntegrationTestBase
{
	public static IEnumerable<TestCaseData> ApplicationCreateRequest_ShouldReturn200Ok_TestCases()
	{
		yield return new TestCaseData(ApplicationCreateRequestTestBuilder.Default().Build());
	}
	
	public static IEnumerable<TestCaseData> ApplicationCreateRequest_ShouldReturn400BadRequest_TestCases()
	{
		yield return new TestCaseData(
			ApplicationCreateRequestTestBuilder.Default()
				.WithFirstName(null)
				.Build(),
			nameof(Domain.Entities.Application.FirstName)
		);
		yield return new TestCaseData(
			ApplicationCreateRequestTestBuilder.Default()
				.WithFirstName(new string('a', AppDefaults.MaxPropertyLength + 1))
				.Build(),
			nameof(Domain.Entities.Application.FirstName)
		);
		yield return new TestCaseData(
			ApplicationCreateRequestTestBuilder.Default()
				.WithLastName(null)
				.Build(),
			nameof(Domain.Entities.Application.LastName)
		);
		yield return new TestCaseData(
			ApplicationCreateRequestTestBuilder.Default()
				.WithLastName(new string('a', AppDefaults.MaxPropertyLength + 1))
				.Build(),
			nameof(Domain.Entities.Application.LastName)
		);
		yield return new TestCaseData(
			ApplicationCreateRequestTestBuilder.Default()
				.WithClub(null)
				.Build(),
			nameof(Domain.Entities.Application.Club)
		);
		yield return new TestCaseData(
			ApplicationCreateRequestTestBuilder.Default()
				.WithClub(new string('a', AppDefaults.MaxPropertyLength + 1))
				.Build(),
			nameof(Domain.Entities.Application.Club)
		);
		yield return new TestCaseData(
			ApplicationCreateRequestTestBuilder.Default()
				.WithRaceId(Guid.Empty)
				.Build(),
			nameof(Domain.Entities.Application.RaceId)
		);
	}

	public static IEnumerable<TestCaseData> ApplicationDeleteRequest_ShouldReturn204NoContent_TestCases()
	{
		var race = RaceTestBuilder.Default().Build();
		var application = ApplicationTestBuilder.Default().WithRaceId(race.Id).Build();
		yield return new TestCaseData(
			race,
			application,
			ApplicationDeleteRequestTestBuilder.Default()
				.WithId(application.Id)
				.Build()
		);
	}
	
	public static IEnumerable<TestCaseData> ApplicationDeleteRequest_ShouldReturn400BadRequest_TestCases()
	{
		yield return new TestCaseData(
			ApplicationDeleteRequestTestBuilder.Default()
				.WithId(Guid.Empty)
				.Build(),
			nameof(ApplicationDeleteRequest.ApplicationId)
		);
	}
	
	public static IEnumerable<TestCaseData> ApplicationGetDetailsRequest_ShouldReturn200Ok_TestCases()
	{
		var race = RaceTestBuilder.Default().Build();
		var application = ApplicationTestBuilder.Default().WithRaceId(race.Id).Build();
		yield return new TestCaseData(
			race,
			application,
			new ApplicationGetDetailsRequest(application.Id),
			ApplicationGetDetailsResponse.From(application)
		);
	}
	
	public static IEnumerable<TestCaseData> ApplicationGetDetailsRequest_ShouldReturn404NotFound_TestCases()
	{
		yield return new TestCaseData(new ApplicationGetDetailsRequest(Guid.NewGuid()));
	}
	
	public static IEnumerable<TestCaseData> ApplicationGetListRequest_ShouldReturn200Ok_TestCases()
	{
		var race = RaceTestBuilder.Default().Build();
		Domain.Entities.Application[] applications =
		[
			ApplicationTestBuilder.Default().WithRaceId(race.Id).Build(),
			ApplicationTestBuilder.Default().WithRaceId(race.Id).Build(),
			ApplicationTestBuilder.Default().WithRaceId(race.Id).Build(),
			ApplicationTestBuilder.Default().WithRaceId(race.Id).Build()
		];
		yield return new TestCaseData(
			race,
			applications,
			new ApplicationGetListRequest(),
			ApplicationGetListResponse.From(applications.ToList())
		);
	}
}