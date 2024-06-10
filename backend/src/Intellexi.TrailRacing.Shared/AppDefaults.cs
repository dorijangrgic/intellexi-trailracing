namespace Intellexi.TrailRacing.Shared;

public static class AppDefaults
{
    public const int MaxPropertyLength = 255;

    public static class Persistence
    {
        public const string ConnectionString = "TrailRacingDb";
        public const string DatabaseName = "intellexi";
        public const string SchemaName = "trail_racing";
    }
    
    public static class ErrorMessages
    {
        public const string EntityNotFound = "{0} with the ID: {1} does not exist.";
    }
}