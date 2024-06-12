using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Application.RaceManagement.Responses;
using Intellexi.TrailRacing.Domain;
using Intellexi.TrailRacing.Domain.Entities;
using Intellexi.TrailRacing.Shared;
using Intellexi.TrailRacing.Tests.Shared.Builders.Domain;
using Intellexi.TrailRacing.Tests.Shared.Builders.Requests;

namespace Intellexi.TrailRacing.QueryService.IntegrationTest.RaceManagement;

internal class RaceManagementTestFixture : IntegrationTestBase
{
	public static IEnumerable<TestCaseData> RaceCreateRequest_ShouldReturn200Ok_TestCases()
	{
		yield return new TestCaseData(RaceCreateRequestTestBuilder.Default().Build());
	}
	
	public static IEnumerable<TestCaseData> RaceCreateRequest_ShouldReturn400BadRequest_TestCases()
	{
		yield return new TestCaseData(
			RaceCreateRequestTestBuilder.Default()
				.WithName(null)
				.Build(),
			nameof(Race.Name)
		);
		yield return new TestCaseData(
			RaceCreateRequestTestBuilder.Default()
				.WithName(new string('a', AppDefaults.MaxPropertyLength + 1))
				.Build(),
			nameof(Race.Name)
		);
		yield return new TestCaseData(
			RaceCreateRequestTestBuilder.Default()
				.WithDistance((RaceDistance)5)
				.Build(),
			nameof(Race.Distance)
		);
	}
	
	public static IEnumerable<TestCaseData> RaceUpdateRequest_ShouldReturn204NoContent_TestCases()
	{
		var race = RaceTestBuilder.Default().Build();
		yield return new TestCaseData(
			race,
			RaceUpdateRequestTestBuilder.Default()
				.WithId(race.Id)
				.WithName("updated race name")
				.WithDistance(RaceDistance.Marathon)
				.Build()
		);
	}
	
	public static IEnumerable<TestCaseData> RaceUpdateRequest_ShouldReturn400BadRequest_TestCases()
	{
		yield return new TestCaseData(
			RaceUpdateRequestTestBuilder.Default()
				.WithId(Guid.Empty)
				.Build(),
			nameof(RaceUpdateRequest.RaceId)
		);
		yield return new TestCaseData(
			RaceUpdateRequestTestBuilder.Default()
				.WithName(null)
				.Build(),
			nameof(Race.Name)
		);
		yield return new TestCaseData(
			RaceUpdateRequestTestBuilder.Default()
				.WithName(new string('a', AppDefaults.MaxPropertyLength + 1))
				.Build(),
			nameof(Race.Name)
		);
		yield return new TestCaseData(
			RaceUpdateRequestTestBuilder.Default()
				.WithDistance((RaceDistance)5)
				.Build(),
			nameof(Race.Distance)
		);
	}
	
	public static IEnumerable<TestCaseData> RaceDeleteRequest_ShouldReturn204NoContent_TestCases()
	{
		var race = RaceTestBuilder.Default().Build();
		yield return new TestCaseData(
			race,
			RaceDeleteRequestTestBuilder.Default()
				.WithId(race.Id)
				.Build()
		);
	}
	
	public static IEnumerable<TestCaseData> RaceDeleteRequest_ShouldReturn400BadRequest_TestCases()
	{
		yield return new TestCaseData(
			RaceDeleteRequestTestBuilder.Default()
				.WithId(Guid.Empty)
				.Build(),
			nameof(RaceDeleteRequest.RaceId)
		);
	}
	
	public static IEnumerable<TestCaseData> RaceGetDetailsRequest_ShouldReturn200Ok_TestCases()
	{
		var race = RaceTestBuilder.Default().Build();
		yield return new TestCaseData(
			race,
			new RaceGetDetailsRequest(race.Id),
			RaceGetDetailsResponse.From(race)
		);
	}
	
	public static IEnumerable<TestCaseData> RaceGetDetailsRequest_ShouldReturn404NotFound_TestCases()
	{
		yield return new TestCaseData(new RaceGetDetailsRequest(Guid.NewGuid()));
	}
	
	public static IEnumerable<TestCaseData> RaceGetListRequest_ShouldReturn200Ok_TestCases()
	{
		Race[] races =
		[
			RaceTestBuilder.Default().Build(),
			RaceTestBuilder.Default().Build(),
			RaceTestBuilder.Default().Build(),
			RaceTestBuilder.Default().Build()
		];
		yield return new TestCaseData(
			races,
			new RaceGetListRequest(),
			RaceGetListResponse.From(races.ToList())
		);
	}
}