using FluentAssertions;
using Intellexi.TrailRacing.Application.Common.ErrorHandling;

namespace Intellexi.TrailRacing.QueryService.IntegrationTest.Helpers;

internal static class AssertExtensions
{
	public static void ContainError(this CustomProblemDetails problemDetails, string propertyName)
	{
		problemDetails.Errors.Should().NotBeEmpty();
		problemDetails.Errors.Should().ContainKey(propertyName);
	}
}
