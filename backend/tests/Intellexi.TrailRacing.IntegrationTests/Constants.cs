namespace Intellexi.TrailRacing.QueryService.IntegrationTest;

public static class Constants
{
	// public const int MaxPropertyLength = 255;
	// public const string TrailRacingConnectionString = "TrailRacingDb";

	public static class Endpoints
	{
		private const string Races = "/api/v1/races";
		private const string Applications = "/api/v1/applications";
		
		public const string RaceCreate = $"{Races}";
		public const string RaceUpdate = $"{Races}/{{0}}";
		public const string RaceDelete = $"{Races}/{{0}}";
		public const string RaceGetList = $"{Races}";
		public const string RaceGetDetails = $"{Races}/{{0}}";
		
		public const string ApplicationCreate = $"{Applications}";
		public const string ApplicationDelete = $"{Applications}/{{0}}";
		public const string ApplicationGetList = $"{Applications}";
		public const string ApplicationGetDetails = $"{Applications}/{{0}}";
	}
}