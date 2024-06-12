using FluentAssertions;
using Intellexi.TrailRacing.Application.Common.ErrorHandling;
using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Application.RaceManagement.Responses;
using Intellexi.TrailRacing.Domain.Entities;
using Intellexi.TrailRacing.QueryService.IntegrationTest.Helpers;

namespace Intellexi.TrailRacing.QueryService.IntegrationTest.RaceManagement;

internal class RaceManagementTests : RaceManagementTestFixture
{
	[TestCaseSource(nameof(RaceCreateRequest_ShouldReturn200Ok_TestCases))]
	public async Task RaceCreateRequest_ShouldReturn200Ok(RaceCreateRequest request)
	{
		// Act
		var result = await CommandClient.PostAsJsonAsync(Endpoints.RaceCreate, request);

		// Assert
		result.Should().Be200Ok();
	}
	
	[TestCaseSource(nameof(RaceCreateRequest_ShouldReturn400BadRequest_TestCases))]
	public async Task RaceCreateRequest_ShouldReturn400BadRequest(
		RaceCreateRequest request,
		string propertyName)
	{
		// Act
		var result = await CommandClient.PostAsJsonAsync(Endpoints.RaceCreate, request);

		// Assert
		result.Should().Be400BadRequest()
			.And
			.Satisfy<CustomProblemDetails>(problemDetails => problemDetails.ContainError(propertyName));
	}

	[TestCaseSource(nameof(RaceUpdateRequest_ShouldReturn204NoContent_TestCases))]
	public async Task RaceUpdateRequest_ShouldReturn204NoContent(
		Race race,
		RaceUpdateRequest request)
	{
		// Arrange
		await AddAsync(race);
		var endpoint = string.Format(Endpoints.RaceUpdate, request.RaceId);

		// Act
		var result = await CommandClient.PutAsJsonAsync(endpoint, request);

		// Assert
		result.Should().Be204NoContent();
	}
	
	[TestCaseSource(nameof(RaceUpdateRequest_ShouldReturn400BadRequest_TestCases))]
	public async Task RaceUpdateRequest_ShouldReturn400BadRequest(
		RaceUpdateRequest request,
		string propertyName)
	{
		// Arrange
		var endpoint = string.Format(Endpoints.RaceUpdate, request.RaceId);

		// Act
		var result = await CommandClient.PutAsJsonAsync(endpoint, request);

		// Assert
		result.Should().Be400BadRequest()
			.And
			.Satisfy<CustomProblemDetails>(problemDetails => problemDetails.ContainError(propertyName));
	}

	[TestCaseSource(nameof(RaceDeleteRequest_ShouldReturn204NoContent_TestCases))]
	public async Task RaceDeleteRequest_ShouldReturn204NoContent(
		Race race,
		RaceDeleteRequest request)
	{
		// Arrange
		await AddAsync(race);
		var endpoint = string.Format(Endpoints.RaceDelete, request.RaceId);

		// Act
		var result = await CommandClient.DeleteAsync(endpoint);

		// Assert
		result.Should().Be204NoContent();
	}
	
	[TestCaseSource(nameof(RaceDeleteRequest_ShouldReturn400BadRequest_TestCases))]
	public async Task RaceDeleteRequest_ShouldReturn400BadRequest(
		RaceDeleteRequest request,
		string propertyName)
	{
		// Arrange
		var endpoint = string.Format(Endpoints.RaceDelete, request.RaceId);

		// Act
		var result = await CommandClient.PutAsJsonAsync(endpoint, request);

		// Assert
		result.Should().Be400BadRequest()
			.And
			.Satisfy<CustomProblemDetails>(problemDetails => problemDetails.ContainError(propertyName));
	}
	
	[TestCaseSource(nameof(RaceGetDetailsRequest_ShouldReturn200Ok_TestCases))]
	public async Task RaceGetDetailsRequest_ShouldReturn200Ok(
		Race race,
		RaceGetDetailsRequest request,
		RaceGetDetailsResponse expectedResponse)
	{
		// Arrange
		await AddAsync(race);
		var endpoint = string.Format(Endpoints.RaceGetDetails, request.RaceId);

		// Act
		var result = await QueryClient.GetAsync(endpoint);

		// Assert
		result.Should()
			.Be200Ok()
			.And
			.Satisfy<RaceGetDetailsResponse>(response => response.Should().BeEquivalentTo(expectedResponse));
	}
	
	[TestCaseSource(nameof(RaceGetDetailsRequest_ShouldReturn404NotFound_TestCases))]
	public async Task RaceGetDetailsRequest_ShouldReturn404NotFound(RaceGetDetailsRequest request)
	{
		// Arrange
		var endpoint = string.Format(Endpoints.RaceGetDetails, request.RaceId);

		// Act
		var result = await QueryClient.GetAsync(endpoint);

		// Assert
		result.Should().Be404NotFound();
	}
	
	[TestCaseSource(nameof(RaceGetListRequest_ShouldReturn200Ok_TestCases))]
	public async Task RaceGetListRequest_ShouldReturn200Ok(
		Race[] races,
		RaceGetListRequest request,
		RaceGetListResponse expectedResponse)
	{
		// Arrange
		await InsertAsync(races);

		// Act
		var result = await QueryClient.GetAsync(Endpoints.RaceGetList);

		// Assert
		result.Should().Be200Ok()
			.And
			.Satisfy<RaceGetListResponse>(response => response.Should().BeEquivalentTo(expectedResponse));
	}
}