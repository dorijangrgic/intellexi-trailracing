using FluentAssertions;
using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;
using Intellexi.TrailRacing.Application.ApplicationManagement.Responses;
using Intellexi.TrailRacing.Application.Common.ErrorHandling;
using Intellexi.TrailRacing.Domain.Entities;
using Intellexi.TrailRacing.QueryService.IntegrationTest.Helpers;

namespace Intellexi.TrailRacing.QueryService.IntegrationTest.ApplicationManagement;

internal class ApplicationManagementTests : ApplicationManagementTestFixture
{
	[TestCaseSource(nameof(ApplicationCreateRequest_ShouldReturn200Ok_TestCases))]
	public async Task ApplicationCreateRequest_ShouldReturn200Ok(ApplicationCreateRequest request)
	{
		// Act
		var result = await CommandClient.PostAsJsonAsync(Endpoints.ApplicationCreate, request);

		// Assert
		result.Should().Be200Ok();
	}
	
	[TestCaseSource(nameof(ApplicationCreateRequest_ShouldReturn400BadRequest_TestCases))]
	public async Task ApplicationCreateRequest_ShouldReturn400BadRequest(
		ApplicationCreateRequest request,
		string propertyName)
	{
		// Act
		var result = await CommandClient.PostAsJsonAsync(Endpoints.ApplicationCreate, request);

		// Assert
		result.Should().Be400BadRequest()
			.And
			.Satisfy<CustomProblemDetails>(problemDetails => problemDetails.ContainError(propertyName));
	}

	[TestCaseSource(nameof(ApplicationDeleteRequest_ShouldReturn204NoContent_TestCases))]
	public async Task ApplicationDeleteRequest_ShouldReturn204NoContent(
		Race race,
		Domain.Entities.Application application,
		ApplicationDeleteRequest request)
	{
		// Arrange
		await AddAsync(race);
		await AddAsync(application);
		var endpoint = string.Format(Endpoints.ApplicationDelete, request.ApplicationId);

		// Act
		var result = await CommandClient.DeleteAsync(endpoint);

		// Assert
		result.Should().Be204NoContent();
	}
	
	[TestCaseSource(nameof(ApplicationDeleteRequest_ShouldReturn400BadRequest_TestCases))]
	public async Task ApplicationDeleteRequest_ShouldReturn400BadRequest(
		ApplicationDeleteRequest request,
		string propertyName)
	{
		// Arrange
		var endpoint = string.Format(Endpoints.ApplicationDelete, request.ApplicationId);

		// Act
		var result = await CommandClient.DeleteAsync(endpoint);

		// Assert
		result.Should().Be400BadRequest()
			.And
			.Satisfy<CustomProblemDetails>(problemDetails => problemDetails.ContainError(propertyName));
	}
	
	[TestCaseSource(nameof(ApplicationGetDetailsRequest_ShouldReturn200Ok_TestCases))]
	public async Task ApplicationGetDetailsRequest_ShouldReturn200Ok(
		Race race,
		Domain.Entities.Application application,
		ApplicationGetDetailsRequest request,
		ApplicationGetDetailsResponse expectedResponse)
	{
		// Arrange
		await AddAsync(race);
		await AddAsync(application);
		var endpoint = string.Format(Endpoints.ApplicationGetDetails, request.ApplicationId);

		// Act
		var result = await QueryClient.GetAsync(endpoint);

		// Assert
		result.Should()
			.Be200Ok()
			.And
			.Satisfy<ApplicationGetDetailsResponse>(response => response.Should().BeEquivalentTo(expectedResponse));
	}
	
	[TestCaseSource(nameof(ApplicationGetDetailsRequest_ShouldReturn404NotFound_TestCases))]
	public async Task ApplicationGetDetailsRequest_ShouldReturn404NotFound(ApplicationGetDetailsRequest request)
	{
		// Arrange
		var endpoint = string.Format(Endpoints.ApplicationGetDetails, request.ApplicationId);

		// Act
		var result = await QueryClient.GetAsync(endpoint);

		// Assert
		result.Should().Be404NotFound();
	}
	
	[TestCaseSource(nameof(ApplicationGetListRequest_ShouldReturn200Ok_TestCases))]
	public async Task ApplicationGetListRequest_ShouldReturn200Ok(
		Race race,
		Domain.Entities.Application[] applications,
		ApplicationGetListRequest request,
		ApplicationGetListResponse expectedResponse)
	{
		// Arrange
		await AddAsync(race);
		await InsertAsync(applications);

		// Act
		var result = await QueryClient.GetAsync(Endpoints.ApplicationGetList);

		// Assert
		result.Should().Be200Ok()
			.And
			.Satisfy<ApplicationGetListResponse>(response => response.Should().BeEquivalentTo(expectedResponse));
	}
}